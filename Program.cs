using Carter;
using LibCarter;
using LibCarter.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(builder => builder.UseInMemoryDatabase("CarterDemo"));

builder.Services.AddCarter();
builder.Services.AddScoped<ICarRepository, CarRepository>();

var app = builder.Build();

app.MapCarter();
app.Run();
