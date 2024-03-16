using Lib.AspNetCore.ServerSentEvents;
using ManagementSystem.MainApp.Services;
using ManagementSystem.MainApp.Services.IServices;
using ManagementSystem.MainApp.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IInventoryVoucherService, InventoryVoucherService>();
builder.Services.AddHttpClient<IReceiptService, ReceiptService>();
builder.Services.AddHttpClient<IEventloggingService, EventLoggingService>();
builder.Services.AddHttpClient<IUserService, UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.AddServerSentEvents<INotificationsServices, NotificationsServices>();
builder.Services.AddScoped<IPaymentServices, PaymentServices>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IInventoryVoucherService, InventoryVoucherService>();
builder.Services.AddScoped<IReceiptService, ReceiptService>();
builder.Services.AddScoped<IEventloggingService, EventLoggingService>();
builder.Services.AddScoped<IUserService, UserService>();

SD.AccountingApiUrl = builder.Configuration["ServicesUrls:AccountingApi"];
SD.AccountApiUrl = builder.Configuration["ServicesUrls:AccountApi"];
SD.StorageApiUrl = builder.Configuration["ServicesUrls:StorageApi"];
SD.MainApiUrl = builder.Configuration["ServicesUrls:MainApi"];

SD.ETaxCode = builder.Configuration["ElectronicBill:TaxCode"];
SD.EPatern = builder.Configuration["ElectronicBill:Patern"];
SD.EIKey = builder.Configuration["ElectronicBill:IKey"];
SD.EUserName = builder.Configuration["ElectronicBill:UserName"];
SD.EPassword = builder.Configuration["ElectronicBill:Password"];
SD.EUrl = builder.Configuration["ElectronicBill:URL"];

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "MainApp", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();
app.UseCors("AllowAllOrigins");
app.MapControllers();
app.MapServerSentEvents<NotificationsServices>("/api/sse", new ServerSentEventsOptions
{
    RequireAcceptHeader = false,
    OnPrepareAccept = response =>
    {
        response.Headers.Append("Cache-Control", "no-cache");
        response.Headers.Append("X-Accel-Buffering", "no");
    }
});

app.Run();
