using ExtractAppSettingsValue.Middleware;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Way:1
var getEndpoint = builder.Configuration.GetValue<string>("AuthToken:Endpoint");

//Way:2
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var way_2_getEndpoint = configuration.GetValue<string>("AuthToken:Endpoint");


// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{

    options.Filters.Add<AuthenticationMiddleware>();
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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
