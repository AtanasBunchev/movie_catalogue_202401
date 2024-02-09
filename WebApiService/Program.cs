using Microsoft.EntityFrameworkCore;
using MC.Data.Contexts;
using MC.ApplicationServices.Implementation;
using MC.ApplicationServices.Interfaces;
using System.Reflection;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("Hello, world!");

try {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
    builder.Services.AddDbContext<MovieDbContext>(options => {
        options.UseSqlServer(connectionString);
    });
    //builder.Services.AddDatabaseDeveloperPAgeExceptionFilter();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
    //    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });

    // DI
    builder.Services.AddScoped<IMoviesService, MoviesService>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    await Log.CloseAndFlushAsync();
}

