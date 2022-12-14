using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Data;
using WebApi.Interfaces;
using WebApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata= false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = "http://localhost",
        ValidAudience = "http://localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Abdullah")),
        ValidateIssuerSigningKey =true,
        ValidateLifetime= true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddDbContext<ProductContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("CorePolicy", opt =>
    {
        opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling =Newtonsoft.Json.ReferenceLoopHandling.Ignore; 

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("CorePolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
