using BuildingWorks.Infrastructure;
using BuildingWorksServer.Extensions;
using BuildingWorksServer.Logging;
using BuildingWorksServer.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOptions(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOptions();
builder.Services.AddControllers();
builder.Services.AddDbContext();
builder.Services.ConfigureServices();
builder.Services.AddSwaggerGen();

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddTransient<HttpClientLoggingHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAutoWrapper();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

await app.Services.ApplyMigrations();

app.Run();
