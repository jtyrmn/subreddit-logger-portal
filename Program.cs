using subreddit_logger_portal.Models;
using subreddit_logger_portal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// configuration
EnvironmentVariablesModel environmentVariables = new();
builder.Configuration.Bind(environmentVariables);
builder.Services.AddSingleton(environmentVariables);

// the database service
builder.Services.AddSingleton<ListingsService>();

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

//because I want a cleaner url for the listings endpoint
// app.MapControllerRoute(
//     name: "listings",
//     pattern: "listings/{id?}",
//     defaults: new { controller = "Listings", action = "Index" }
// );

app.Run();