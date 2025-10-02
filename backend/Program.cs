using backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddSpaStaticFiles(configuration =>
// {
//     configuration.RootPath = "ClientApp/dist"; // Path to your built SPA files
// });

// specify url in appsettings
var appSettings = builder.Configuration.GetSection("ApiSettings");
var frontEndUrl = appSettings["FrontEndUrl"];

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(frontEndUrl)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
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
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.UseStaticFiles();
// app.UseSpaStaticFiles();
app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// app.UseSpa(spa =>
// {
//     spa.Options.SourcePath = "../frontend/"; // Path to your SPA source code
//
//     if (app.Environment.IsDevelopment())
//     {
//         // Use a proxy to the SPA development server
//         spa.UseProxyToSpaDevelopmentServer("http://localhost:5173"); // Or your SPA dev server URL
//         // Or if using a template, it might use spa.UseAngularCliServer or similar
//     }
// });
//

app.Run();
