using Appo.Aplication.Utilities.Mediator;

namespace Appo.Application.Features.Appoiments.CreatedAppoiment
{
    public class CreatedAppoimentCommand: IRequest
    {
    	public DateTime Start { get; set; }
    	public DateTime Finish { get; set; }
		public Guid CustomerId { get; set; }
		public Guid? PartnerId { get; set; }
		public string? CustomerRequest { get; set; }

    }
}
