using System.Net;
using System.Text.Json;
using Appo.Aplication.Exceptions;
using Appo.Application.Exceptions;

namespace Appo.API.Middleware
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionHandlerMiddleware(RequestDelegate next)
		{
			this._next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandlerException(context, ex);
			}
		}


		private Task HandlerException(HttpContext context, Exception ex)
		{
			HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
			context.Response.ContentType = "application/json";
			var result = string.Empty;

			// TODO: Verificar que ya esten todas las excepciones puestas aca
			switch (ex)
			{
				case NotFoundException:
					statusCode = HttpStatusCode.NotFound;
					break;
				case AppoValidationException:
					statusCode = HttpStatusCode.BadRequest;
					result = JsonSerializer.Serialize(AppoValidationException.ValidationErrors);
					break;
				case AppoTenantException:
					statusCode = HttpStatusCode.InternalServerError;
					break;

			}

			context.Response.StatusCode = (int)statusCode;
			return context.Response.WriteAsync(result);

		}

	}

	//?: Clase para facilitar el uso del middleware
	public static class HarlerExceptionMiddlewareExtensions
	{
		public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ExceptionHandlerMiddleware>();
		}
	}
}
