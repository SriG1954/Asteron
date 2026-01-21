using AppCoreV1.Data;
using AppCoreV1.Helper;
using AppCoreV1.Interfaces;
using AppCoreV1.Repositories;
using AppCoreV1.Services;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using WebAppV1.Helpers;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

//string encriptedString = config.GetConnectionString("ABLEConnection") ?? string.Empty;
//string _connectionString = AESSecurity.Decrypt(encriptedString);

string _ableConnectionString = config.GetConnectionString("ABLEConnection") ?? string.Empty;
string _asteronConnectionString = config.GetConnectionString("AsteronConnection") ?? string.Empty;

//string _connectionString2 = AESSecurity.Encrypt(_connectionString);
//string _connectionString3 = AESSecurity.Decrypt(_connectionString2);


var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
var logger = new LoggerConfiguration().WriteTo
    .MSSqlServer(
                    connectionString: _ableConnectionString,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "FLLogs",
                        SchemaName = "dbo",
                        AutoCreateSqlTable = true
                    },
                    restrictedToMinimumLevel: LogEventLevel.Debug,
                    formatProvider: null,
                    columnOptions: null,
                    logEventFormatter: null)
    .MinimumLevel.Error()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Host.UseSerilog(logger);

// Configure Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "ABLESession";
});

// add ABLE connection
builder.Services.AddDbContext<AbleDBContext>(options => options.UseSqlServer(_ableConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(120)));

// add Asteron connection
builder.Services.AddDbContext<AsteronDbContext>(options => options.UseSqlServer(_asteronConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(120)));

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddTransient<IPageHelper, PageHelper>();
builder.Services.AddTransient<IABLEPageHelper, ABLEPageHelper>();
builder.Services.AddSingleton<IS3Service, S3Service>();

builder.Services.AddTransient<IAbleSearch, AbleSearch>();
builder.Services.AddTransient<IXLSAbleHelper, XLSAbleHelper>();
builder.Services.AddTransient<IABLEExport, ABLEExport>();

builder.Services.AddTransient<IAsteronSearch, AsteronSearch>();
builder.Services.AddTransient<IXLSAsteronHelper, XLSAsteronHelper>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
//app.UseStaticFiles();
app.UseRouting();

// configure static files
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
    }
});

app.UseAuthentication();
app.UseAuthorization();
app.UseSerilogRequestLogging();
app.UseSession();

// configure custom headers
app.Use(async (context, next) =>
{
    var headers = context.Response.Headers;
    headers.Append("X-Frame-Options", "DENY");
    headers.Append("X-XSS-Protection", "1; mode=block");
    headers.Append("X-Content-Type-Options", "nosniff");
    await next();
});

// set secure coolies
app.UseCookiePolicy(new CookiePolicyOptions
{
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
    MinimumSameSitePolicy = SameSiteMode.Strict
});

// use middleware to validate login user
//app.UseMiddleware<ValidateABLELoginUser>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
