using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Task5_webapiCrudoperationsdbfirstservicelayer_.Model;
using Task5_webapiCrudoperationsdbfirstservicelayer_.ServiceLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.File;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.AzureAppServices;


var builder = WebApplication.CreateBuilder(args);
//file
//builder.Host.ConfigureLogging(logging =>
//{
//    logging.ClearProviders(); // Clear other logging providers

//    // Add AzureFileLogger using options
//    logging.AddAzureFile(options =>
//    {
//        options.LogDirectory = "your_log_directory";
//        options.FileName = "your_log_file.txt";
//    });
//});

// Configure Serilog for logging
//Log.Logger = new LoggerConfiguration()
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
//    {
//        AutoRegisterTemplate = true,
//    })
//    .CreateLogger();

//builder.Host.UseSerilog((context, configuration) => configuration
//    .ReadFrom.Configuration(context.Configuration)
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .WriteTo.File("D:\\Task5(webapiCrudoperationsdbfirstservicelayer)log\\log.txt", rollingInterval: RollingInterval.Day));




//builder.Host.UseSerilog(); // UseSerilog extension method for WebHostBuilder

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionstring")));

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
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
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseAuthorization();

app.MapControllers();


app.Run();
