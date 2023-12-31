using Anket.Common;
using DomainService.DBService;
using BasePersonDBService.DataContext;
using DSUContextDBService.DataContext;
using Microsoft.EntityFrameworkCore;
using Sentry;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Repository.Interface;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
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
    options.AddPolicy("MyAllowCredentialsPolicy",
        policy =>
        {
            policy.WithOrigins(builder.Configuration["LinkToFrontEnd"])
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

builder.Services.AddDbContext<BASEPERSONMDFContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BasePerson"), providerOptions => providerOptions.EnableRetryOnFailure()));
builder.Services.AddDbContext<DSUContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BaseDekanat"), providerOptions => providerOptions.EnableRetryOnFailure()));
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Anket"), providerOptions => providerOptions.EnableRetryOnFailure()));

builder.WebHost.ConfigureServices(configure => SentrySdk.Init(o =>
{
    // Tells which project in Sentry to send events to:
    o.Dsn = builder.Configuration["SentyDSN"]; ;
    // When configuring for the first time, to see what the SDK is doing:
    o.Debug = true;
    // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
    // We recommend adjusting this value in production.
    o.TracesSampleRate = 1.0;
    // Enable Global Mode if running in a client app
    o.IsGlobalModeEnabled = true;
}));

builder.Services.AddServiceCollection();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // ���������, ����� �� �������������� �������� ��� ��������� ������
            ValidateIssuer = true,
            // ������, �������������� ��������
            ValidIssuer = builder.Configuration["ISSUER"],
            // ����� �� �������������� ����������� ������
            ValidateAudience = true,
            // ��������� ����������� ������
            ValidAudience = builder.Configuration["AUDIENCE"],
            // ����� �� �������������� ����� �������������
            ValidateLifetime = true,
            // ��������� ����� ������������
            IssuerSigningKey = new AuthOptions(builder.Configuration).GetSymmetricSecurityKey(),
            // ��������� ����� ������������
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<IEmployeeRepository>();
    var rolesManager = scope.ServiceProvider.GetRequiredService<IRoleRepository>();
    if (userManager.Get().Count() == 0)
    {
        string adminLogin = builder.Configuration["AdminLogin"];
        string password = builder.Configuration["AdminPassword"];
        await RoleInitializer.InitializeAsync(adminLogin, password, userManager, rolesManager);
    }
}

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyAllowCredentialsPolicy");

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();