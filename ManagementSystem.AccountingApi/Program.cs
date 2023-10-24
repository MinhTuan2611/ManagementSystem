using ManagementSystem.AccountingApi.Data;
using ManagementSystem.AccountingApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AcountingsDbConnStr");
builder.Services.AddDbContext<AccountingDbContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DI
builder.Services.AddScoped<IReceiptService, ReceiptService>();
builder.Services.AddScoped<IInventoryVoucherService, InventoryVoucherService>();
builder.Services.AddScoped<ILegerService, LegerService>();
builder.Services.AddScoped<IPaymentVoucherService, PaymentVoucherService>();
builder.Services.AddScoped<IOtherAccountEntryService, OtherAccountEntryService>();
builder.Services.AddScoped<IEmployeeShiftReportService, EmployeeShiftReportService>();


//// Excluded migration tables
//var migrationConfigs = new MigrationsConfiguration();

////var excludedTables = AccountingTableName.GenerateExcludedTableName();
////var count = excludedTables.Count;
////for (int i = 0; i < count; i++)
////{
////    var name = excludedTables[i];

////    // Modify the collection if needed
////    migrationConfigs.ExcludedTableNames.Add(name);
////}

////migrationConfigs.ExcludedTableTypes.Add(typeof(ScalarResult<int>));

//builder.Services.AddSingleton(migrationConfigs);

var app = builder.Build();

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
