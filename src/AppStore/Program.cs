using Microsoft.Extensions.Options;
using AppStore.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddDbContext<DatabaseContext>(options => options.LogTo(Console.WriteLine, new []){}.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder. Services.AddDbContext<DatabaseContext> (opt => {
    opt.LogTo(Console.WriteLine, new [] {
        DbLoggerCategory.Database.Command.Name},
        LogLevel.Information) .EnableSensitiveDataLogging().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    // opt.UseSqlite(builder.Configuration.GetConnectionString("SqliteDatabase"));
    // .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
