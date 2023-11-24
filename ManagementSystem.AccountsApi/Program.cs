using ManagementSystem.AccountsApi.SeedingData;
using ManagementSystem.AccountsApi.Services;
using ManagementSystem.EmployeesApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AccountsDbConnStr");
builder.Services.AddDbContext<AccountsDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IEventLoggingService, EventLoggingService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
var app = builder.Build();

// Seeding Data
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var context = services.GetService<AccountsDbContext>();
//    //DataSeeder.SeedData(context);
//}

// Configure the HTTP request pipeline.
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
