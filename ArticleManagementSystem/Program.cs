using AMS.DataAcessLayer.RepoInterfaceImpl;
using AMS.DataAcessLayer.RepoInterfaces;
using AMS.ServiceLayer.ServiceInterfaceImpl;
using AMS.ServiceLayer.ServiceInterfaces;
using System.Data;
using System.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);
var dbConnectionString = builder.Configuration.GetConnectionString("Connection");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<IForgotPasswService, ForgotPasswService>();
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IDashboardService, DashboardService>();
builder.Services.AddTransient<ILoginRepo, LoginRepo>();
builder.Services.AddTransient<IRegisterRepo, RegisterRepo>();
builder.Services.AddTransient<IForgotPasswRepo, ForgotPasswRepo>();
builder.Services.AddTransient<IArticleRepo, ArticleRepo>();
builder.Services.AddTransient<IDashboardRepo, DashboardRepo>();
builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession((sp) =>
{
    sp.IdleTimeout = TimeSpan.FromSeconds(10000);
    sp.Cookie.HttpOnly = true;
    sp.Cookie.IsEssential = true;
});
builder.Services.AddControllersWithViews();


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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
    

app.Run();
