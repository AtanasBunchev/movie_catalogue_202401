using Microsoft.EntityFrameworkCore;
using MC.WebApiService.Data;
using MC.ApplicationServices.Implementation;
using MC.ApplicationServices.Interface;

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
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddScoped<IMovieServices, MovieServices>();

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
