using Microsoft.EntityFrameworkCore;
using TrackWise.Database;
using TrackWise.Database.Repository;
using TrackWise.Database.Repository.Interface;
using TrackWise.Services.Implementations;
using TrackWise.Services.Interfaces;
using TrackWise.Services.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TrackWiseDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPortfolioRepository,PortfolioRepository>();
builder.Services.AddScoped<IPortfolioService,PortfolioService>();

builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();

builder.Services.AddAutoMapper(cfg => { },
    typeof(ServiceMappingProfile).Assembly);



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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
