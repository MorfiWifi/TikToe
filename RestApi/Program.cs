using System.Reflection;
using Application.Interfaces;
using Application.Services;
using Data;
using Data.Interfaces;
using Data.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using RestApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

//register project IRouteEndpoint services
builder.Services.AddEndpointsFromAssembly(Assembly.GetExecutingAssembly());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//register custom services
builder.Services.AddSingleton<ITickToeHandler, TickToeHandler>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IActionService, ActionService>();


var configuration = builder.Configuration;
builder.Services.AddDbContext<TickToeDbContext>(
    options => options.UseSqlite(configuration.GetConnectionString("TickToeDbContext")));

//register repositories
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IActionRepository, ActionRepository>();


var app = builder.Build();

// Create database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TickToeDbContext>();
    _ = dbContext.Database.EnsureCreated(); 
}

//use middle ware exception handler
app.UseMiddleware<HttpExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//disable redirection for development
// app.UseHttpsRedirection();

//register project IRouteEndpoint 
app.RegisterEndpoints();
app.Run();
