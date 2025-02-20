using Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApplication1.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("ShopContextConnection")
    ?? throw new InvalidOperationException("Connection string 'ShopContextConnection' not found.");

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlite(connectionString));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ShopContext>();


builder.Services.AddMemoryCache();
builder.Services.AddSession();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseMiddleware<LastVisitMiddleware>();

app.Use(async (context, next) =>
{
    var requestContent = new StringBuilder();
    requestContent.AppendLine("=== Request Info ===");
    requestContent.AppendLine($"method = {context.Request.Method.ToUpper()}");
    requestContent.AppendLine($"path = {context.Request.Path}");
    requestContent.AppendLine("-- headers");
    foreach (var (headerkey, headerValue) in context.Request.Headers)
    {
        requestContent.AppendLine($"header = {headerkey} value = {headerValue}");
    }

    requestContent.AppendLine("-- body");
    context.Request.EnableBuffering();
    var requestReader = new StreamReader(context.Request.Body);
    var content = await requestReader.ReadToEndAsync();
    requestContent.AppendLine($"body = {content}");
    Console.Write(requestContent.ToString());
    context.Request.Body.Position = 0;
    await next();
});

app.Run();
