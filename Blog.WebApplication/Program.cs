using Blog.WebApplication.Models;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var baseUrl = new ServerBaseUrlViewModel();
builder.Configuration.GetSection("Server_BaseUrl").Bind(baseUrl);
builder.Services.AddSingleton(baseUrl);

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

app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (HttpRequestException ex)
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync("خطا در برقراری ارتباط با سرور");
    }
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
