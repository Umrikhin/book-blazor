using Microsoft.AspNetCore.Components.Authorization;
using RealtyWeb_Client.Models;
using System.Security.Claims;

namespace RealtyWeb_Client.Utils
{
    public class SpecialAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public SpecialAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthenticationState CreateAnonymous()
            {
                var anonymousIdentity = new ClaimsIdentity();
                var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
                return new AuthenticationState(anonymousPrincipal);
            }

            var token = await _localStorageService.GetAsync<SecurityToken>(nameof(SecurityToken));
            if (token == null)
            {
                return CreateAnonymous();
            }

            //Здесь можно добавить проверку существования пользователя в базе данных
            if (string.IsNullOrEmpty(token.UserName) | token.ExpiredAt < DateTime.UtcNow)
            {
                return CreateAnonymous();
            }

            //Создание AuthenticationState реального пользователя
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, token.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.Expired, token.ExpiredAt.ToLongDateString())
            };
            var identity = new ClaimsIdentity(claims, "Token");
            var principal = new ClaimsPrincipal(identity);
            return new AuthenticationState(principal);
        }

        public void MakeUserAnonymous()
        {
            _localStorageService.RemoveAsync(nameof(SecurityToken));

            var anonymousIdentity = new ClaimsIdentity();
            var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);
            var authState = Task.FromResult(new AuthenticationState(anonymousPrincipal));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
