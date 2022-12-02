using Business.Microsoft;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencies();
builder.Services.AddControllersWithViews(); //MVC

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider =new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),RequestPath ="/node_modules"
    }
    );

app.UseRouting();

app.UseAuthorization();

//MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
