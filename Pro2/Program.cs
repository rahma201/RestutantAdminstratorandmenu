using Microsoft.EntityFrameworkCore;
using Pro2.Data.Intercptors;
using Pro2.Data;
using Pro2.Helpers.Email;
using Pro2.Helpers.File;
using Pro2.Helpers;
using Pro2.Repositories;

using Pro2.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Pro2Context>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).AddInterceptors(new SoftDeleteInterceptor()));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddSingleton<IFileHelper, FileHelper>();
builder.Services.AddSingleton<IEmailHelper, EmailHelper>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<Pro2Context>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Admin/Account/Login";
    x.LogoutPath = "/Home/Index";
    x.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    x.SlidingExpiration = true;
});
builder.Services.Configure<IdentityOptions>(x =>
{
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequiredLength = 3;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
