using Microsoft.EntityFrameworkCore;
using WebShoop;
using WebShoop.Components;
using WebShoop.Data;


var builder = WebApplication.CreateBuilder(args);
 

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
   
});
builder.Services.AddScoped<ProductService>();
var app = builder.Build();
if (args.Length == 1 && args[0].ToLower() == "SeedData")
{
    SeedData.Initialize(app);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
