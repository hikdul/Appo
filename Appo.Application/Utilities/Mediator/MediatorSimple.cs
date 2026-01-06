using Appo.Aplication.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace Appo.Aplication.Utilities.Mediator
{
	public class MediatorSimple: IMediator
	{
		private readonly IServiceProvider serviceProvider;

		public MediatorSimple(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
		{
			await ExecValidations(request);

			//?: aca se esta usando Reflexion
			var FeatureType = typeof(IRequestHandler<,>).MakeGenericType(
					request.GetType(),
					typeof(TResponse)
					);

			var Feature = serviceProvider.GetService(FeatureType);

			if (Feature is null)
			{
				throw new MediatorException(
						$"No se encontro un handler para {request.GetType().Name}"
						);
			}

			var action = FeatureType.GetMethod("Handle")!;
			return await (Task<TResponse>)action.Invoke(Feature, new object[] { request })!;
		}
/*
		public async Task Send(IRequest request)
		{
			await ExecValidations(request);

			var FeatureType = typeof(IRequestHandler<>).MakeGenericType(request.GetType());
			var Feature = serviceProvider.GetService(FeatureType);

			if (Feature is null)
			{
				throw new MediatorException(
						$"No se encontro un handler para {request.GetType().Name}"
						);
			}

			var action = FeatureType.GetMethod("Handle")!;
			await (Task)action.Invoke(Feature, new object[] { request })!;
		}
		*/

		private async Task ExecValidations(object request)
		{
			//~: trabajamos con las validaciones, para tenerlas aca y asi si existen que simplemente se ejecuten en este llamado.

			var tipoValidador = typeof(IValidator<>).MakeGenericType(request.GetType());
			var validador = serviceProvider.GetService(tipoValidador);

			if (validador is not null)
			{
				var actionValidar = tipoValidador.GetMethod("ValidateAsync");
				var tareaValidar = (Task)
					actionValidar!.Invoke(
							validador,
							new object[] { request, CancellationToken.None }
							)!;

				await tareaValidar.ConfigureAwait(false); //?: esto en .NET no es viable, pero para otros modelos de desarrolla si ya que ironicamente con esto se indica que no use el hilo principal para esperar

				var resultado = tareaValidar.GetType().GetProperty("Result");
				var validationResult = (ValidationResult)resultado!.GetValue(tareaValidar)!;
				if (!validationResult.IsValid)
				{
					throw new AppoValidationException(validationResult);
				}
			}
		}
		
	}
}
