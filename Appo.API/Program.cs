
using Appo.Application;
using Appo.Persistence;
using Appo.API.Middleware;
using Appo.Identity.Models;
using Appo.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//

builder.Services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorization(opt => {
		//TODO: verificar si esto es funcional o si solo estorba
		//NOTE: en teorio existe hasta ahora 4 tipos de usuarios sa(yo), admin(que es dependiendo de la emrpesa), partnert(que tambien es basado en la empresa), customen (que es cualquiera).. donde estos usuarios tienen un estilo de trabajo y permisos bastante complejo.
		opt.AddPolicy("esadmin", polycy => polycy.RequireClaim("esadmin"));
});

builder.Services.AddControllers(opt =>{
			opt.Filters.Add(new AuthorizeFilter("esadmin")); //! con esto todas las rutas estan protegidas dentro del API
			opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());//! esto para proteger a mis clientes de ataques anti forgery
});

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
