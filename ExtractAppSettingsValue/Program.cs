using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Way:1
var clusterSettingsPass = builder.Configuration.GetValue<string>("ClusterSettings:Password");

//Way:2
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var clusterSettings = configuration.GetValue<string>("ClusterSettings:Host");


// Add services to the container.
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
