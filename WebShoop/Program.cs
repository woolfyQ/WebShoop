using Microsoft.EntityFrameworkCore;
using WebShoopClient.Components;
using WebShoop.Data;
using Core.Entities;
using Core;
using Infrastructure.Repository;
using Application.Service;
using WebShop.API;
using Core.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure Entity Framework to use Npgsql for PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // <-- Добавление Swagger

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<StorageService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenProvider>();
var app = builder.Build();


if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData.Initialize(app);
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // <-- Включение Swagger
    app.UseSwaggerUI(); // <-- Включение интерфейса Swagger UI
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting(); // Использование маршрутизации
app.UseAuthorization(); // Использование авторизации
app.UseAntiforgery(); // Добавление защиты от CSRF
app.MapControllers();
// Map Razor Components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Run the application
app.Run();