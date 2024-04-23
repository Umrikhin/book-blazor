namespace RealtyWeb_Client.Models
{
    public class SecurityToken
    {
        public string UserName { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiredAt { get; set; }
    }
}
