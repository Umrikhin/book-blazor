using RealtyWeb_Server.Components;
using RealtyWeb_Server.Utils.IService;
using RealtyWeb_Server.Utils;
using Realty_Biz.Repository.IRepository;
using Realty_Biz.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<StateContainerService>();
builder.Services.AddScoped<IRegionRepository, MockRegionRepository>();
builder.Services.AddScoped<IHouseRepository, MockHouseRepository>();
builder.Services.AddScoped<IFileWork, FileWork>();

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

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
