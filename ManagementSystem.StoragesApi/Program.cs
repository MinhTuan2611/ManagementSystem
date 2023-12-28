using ManagementSystem.StoragesApi.Data;
using ManagementSystem.StoragesApi.Mappings;
using ManagementSystem.StoragesApi.SeedingData;
using ManagementSystem.StoragesApi.Services;
using ManagementSystem.StoragesApi.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("StoragesDbConnStr");
builder.Services.AddDbContextPool<DbContext, StoragesDbContext>(options =>
    options.UseSqlServer(connectionString));
SD.AccountDbName = builder.Configuration["DatabaseNames:AccountsDb"];
SD.AccountingDbName = builder.Configuration["DatabaseNames:AccountingDb"];
SD.AccountingApiUrl = builder.Configuration["ServicesUrls:AccountingApi"];
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IEventLoggingService, EventLoggingService>();
builder.Services.AddScoped<IStorageVoucherService, StorageVoucherService>();
builder.Services.AddSwaggerGen();

// Register Auto Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Seeding Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetService<StoragesDbContext>();
    DataSeeder.SeedData(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
