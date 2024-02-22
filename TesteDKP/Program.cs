using Microsoft.EntityFrameworkCore;
using TesteDKP.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<dbContext>
    (options => options.UseSqlServer("Data Source=TOLEN-PC;Initial Catalog=BancoGustavoTolentinoDKP;User=sa;Pwd=123456"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
