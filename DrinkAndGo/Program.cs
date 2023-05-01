using DrinkAndGo.Data;
using DrinkAndGo.Mockers;
using DrinkAndGo.Models;
using DrinkAndGo.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DrinkCS")
));



builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IDrinkRepository, DrinkRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddScoped(sp => ShoppingCart.GetCart(sp));
builder.Services.AddScoped<AppDbContext>();

builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();


var app = builder.Build();

DbInitializer.Seed(app);

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

app.UseSession();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Drinks}/{action=List}/{category?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Drinks}/{action=List}/{id?}");

app.Run();
