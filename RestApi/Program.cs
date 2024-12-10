using System.Reflection;
using RestApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

//register project IRouteEndpoint services
builder.Services.AddEndpointsFromAssembly(Assembly.GetExecutingAssembly());

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
