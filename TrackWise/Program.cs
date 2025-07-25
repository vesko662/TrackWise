using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TrackWise.Database;
using TrackWise.Database.Repository;
using TrackWise.Database.Repository.Interface;
using TrackWise.Models.Entities;
using TrackWise.Seeding;
using TrackWise.Seeding.Seeders;
using TrackWise.Services.Implementations;
using TrackWise.Services.Interfaces;
using TrackWise.Services.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TrackWiseDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TrackWiseDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();

builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IAssetService, AssetService>();

builder.Services.AddScoped<IExchangeRepository, ExchangeRepository>();

builder.Services.AddHttpClient<IFmpService, FmpService>();
builder.Services.AddHttpClient<ICoinGeckoService, CoinGeckoService>();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddTransient<ISeeder, AssetSeeder>();
builder.Services.AddTransient<SeederRunner>();

builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(cfg => { },
    typeof(ServiceMappingProfile).Assembly);

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = $"/Identity/Account/Login";
    opt.LogoutPath = $"/Identity/Account/Logout";
    opt.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<SeederRunner>();
    await runner.RunAsync();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
