using ProbabilityCalculatorAPI.Services;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: false));
    });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Define CORS policy to allow all origins
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin()    // Allow all origins
                        .AllowAnyHeader()    // Allow any headers
                        .AllowAnyMethod());  // Allow any methods
});


// Register the file logging service as a Singleton
builder.Services.AddSingleton<ILogMessageFormatter, LogMessageFormatter>();
builder.Services.AddSingleton<FileLoggingService>();
builder.Services.AddSingleton<DatabaseLoggingService>();

//builder.Services.AddSingleton<ILoggingService, FileLoggingService>();
//builder.Services.AddSingleton<ILoggingService, DatabaseLoggingService>();

builder.Services.AddSingleton<LoggingServiceFactory>();

// Register LogService as a Singleton (since it depends on a Singleton logging service)
builder.Services.AddSingleton<ILogService, LogService>();



builder.Services.AddScoped<ICalculationStrategy, CombinedWithStrategy>();
builder.Services.AddScoped<ICalculationStrategy, EitherStrategy>();
builder.Services.AddScoped<IProbabilityService, ProbabilityService>();
builder.Services.AddScoped<ILogService, LogService>();

var app = builder.Build();

app.UseCors("AllowAllOrigins");

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
