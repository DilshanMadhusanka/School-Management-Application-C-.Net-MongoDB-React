using SchoolManagementApplication.Data;
using SchoolManagementApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// add the midlewears to connect with the mongodb databse

builder.Services.Configure<DataBaseSetting>(
   builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddSingleton<StudentServices>();  // dependancy injection 





builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
