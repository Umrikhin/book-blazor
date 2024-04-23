using RealtyWeb_Server.Components;
using RealtyWeb_Server.Utils.IService;
using RealtyWeb_Server.Utils;
using Realty_Biz.Repository.IRepository;
using Realty_Biz.Repository;
using Radzen;
using System;
using Realty_Db.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<StateContainerService>();
builder.Services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IHouseRepository, HouseRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IFileWork, FileWork>();
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<DialogService>();

//**************Сервисы для аутентификации*********************
builder.Services.AddControllers();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.Name = "realty_auth";
            options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
            options.EventsType = typeof(RealtyWeb_Server.Controllers.CookieAuthenticationEvents);
        });
builder.Services.AddScoped<RealtyWeb_Server.Controllers.CookieAuthenticationEvents>();
builder.Services.AddCascadingAuthenticationState();
//*************************************************************

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseStatusCodePagesWithRedirects("/StatusCode/{0}");
app.UseHttpsRedirection();

//**************Сервисы для аутентификации*********************
app.UseAuthentication();
app.MapControllers();
//*************************************************************

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
