using Microsoft.EntityFrameworkCore;
using Products_Web.Data;
using Products_Web.Repositories;
using Products_Web.Repositories.Interfaces;
using Products_Web.Services;
using Products_Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string connectionString =
    builder.Configuration.GetConnectionString("ApplicationContextConnectionString") ??
    throw new InvalidDataException("Connection string ApplicationContextConnectionString is not found");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(context =>
    context.UseMySQL(connectionString));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
