using Assignment_ASP.Context;
using Assignment_ASP.Helpers.Repositories;
using Assignment_ASP.Helpers.Services;
using Assignment_ASP.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Contexts
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));


// Services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<ContactMessagesService>();
builder.Services.AddScoped<NewsletterService>();

// Repositories
builder.Services.AddScoped<NewsletterRepository>();
builder.Services.AddScoped<ContactMessageRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ProductCategoryRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<AdressRepository>();

//Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedEmail = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireDigit = true;

})  .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<AppUserClaimPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});


var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
