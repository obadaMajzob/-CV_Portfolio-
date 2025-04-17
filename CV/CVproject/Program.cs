using CVproject.Data.Interceptors;
using CVproject.Data;
using CVproject.Helpers.Email;
using CVproject.Repositories;
using Microsoft.EntityFrameworkCore;
using CVproject.Helpers.File;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//// conaction
var con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataDbContext>(x => x.UseSqlServer(con).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).AddInterceptors(new SoftDeleteInterceptor()));



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); 

builder.Services.AddSingleton<IEmailHelper, EmailHelper>();
builder.Services.AddSingleton<IFileHelper, FileHelper>();

//// Identity Model
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 7;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;
    opt.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<DataDbContext>().AddDefaultTokenProviders();

/////////////////
////  رمز اعاده تعيين كلمه المرور صالح لفتره محدده
builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
   opt.TokenLifespan = TimeSpan.FromHours(2));

//// مشان تغيير الباث ديفولت
builder.Services.ConfigureApplicationCookie(x => { 
    x.LoginPath = "/Admin/Account/Login";
    x.LogoutPath = "/Home/Index";
    x.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    x.SlidingExpiration = true;

});

//// مشان عدل شروط الباسوورد
builder.Services.Configure<IdentityOptions>(x => {
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequiredLength = 3;
    x.Password.RequireLowercase = false; 
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireDigit = false;    
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
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
