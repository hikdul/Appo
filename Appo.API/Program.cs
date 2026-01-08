
using Appo.Application;
using Appo.Persistence;
using Appo.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();


//?: carga de servicios de cada capa
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();

var app = builder.Build();

app.UseExceptionHandlerMiddleware();

// Configure the HTTP request pipelin
if (app.Environment.IsDevelopment())
{
	//TODO: ver si aca puedes usar esto; o mejor continuamos con swagger
    //app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
