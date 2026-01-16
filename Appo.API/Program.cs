
using Appo.Application;
using Appo.Persistence;
using Appo.API.Middleware;
using Appo.Identity.Models;
using Appo.Identity;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();


//?: carga de servicios de cada capa
string DatabaseName = "name=AppoDB";
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(DatabaseName);
builder.Services.AddIdentityServices(DatabaseName);

var app = builder.Build();

app.MapIdentityApi<User>();

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
