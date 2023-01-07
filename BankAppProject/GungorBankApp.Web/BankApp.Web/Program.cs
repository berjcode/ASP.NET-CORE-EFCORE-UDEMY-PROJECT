using BankApp.Web.Data.Context;
using BankApp.Web.Data.Interfaces;
using BankApp.Web.Data.Repositories;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BankContext>(
    opt =>
    {
        opt.UseSqlServer("server=(localdb)\\ProjectModels;database=BankDb;integrated security =true;");
    });
builder.Services.AddControllersWithViews();

/* builder.Services.AddScoped<IUserRepository,UserRepository>(); //DI uyguladýk. 
builder.Services.AddScoped<IAccountRepository, AccountRepository>();*/
//builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>)); // Generic Repository Sayesinde Tek seferde yapýyoruz.  Unit Of Work tasarýmý kullandýðýmzýzi için burayýda kaldýrýyoruz.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserMapper, UserMapping>(); // usemappingin görünce ýusemapperi caðýr.
builder.Services.AddScoped<IAccountMapper,AccountMapping>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles(); // wwwroot diþarý açýyoruz. 
app.UseStaticFiles(
    new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/node_modules"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomeIndex}/{id?}");

app.Run();
