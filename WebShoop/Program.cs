using Microsoft.EntityFrameworkCore;
using WebShoopClient.Components;
using WebShoop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configure Entity Framework to use Npgsql for PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register controllers and Swagger before building the app
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // <-- ���������� Swagger

var app = builder.Build();

// Seed data if "SeedData" argument is provided
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
    app.UseSwagger(); // <-- ��������� Swagger
    app.UseSwaggerUI(); // <-- ��������� ���������� Swagger UI
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting(); // ������������� �������������
app.UseAuthorization(); // ������������� �����������
app.UseAntiforgery(); // ���������� ������ �� CSRF

// Map Razor Components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Run the application
app.Run();