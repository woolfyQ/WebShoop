using Microsoft.EntityFrameworkCore;
using WebShoopClient.Components;
using WebShoop.Data;
using Core.Entities;
using Core;
using Infrastructure.Repository;
using Application.Service;
using WebShop.API;
using Core.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //  Добавление Swagger

// Регистрация репозиториев
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<ProductStorage>, StorageRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

// Регистрация сервисов
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<StorageService>();
builder.Services.AddScoped<TokenProvider>();

// Настройка аутентификации JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData.Initialize(app);
}


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

// Добавление аутентификации и авторизации
app.UseAuthentication(); // Использование аутентификации
app.UseAuthorization(); // Использование авторизации
app.UseAntiforgery(); // Добавление защиты от CSRF

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();