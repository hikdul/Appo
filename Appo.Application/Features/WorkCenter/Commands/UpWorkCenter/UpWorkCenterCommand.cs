using Appo.Aplication.Utilities.Mediator;

namespace Appo.Application.Features.WorkCenter.Commands.UpWorkCenter
{
	public class UpWorkCenterCommand: IRequest
	{ 
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Direction { get; set; }
		public int Latitud { get; set; } = 0;
		public int Longitud { get; set; } = 0;
	}
}
