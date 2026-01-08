using Appo.Aplication.Utilities.Mediator;

namespace Appo.Application.Features.WorkCenter.Querys.GetWorkCenterDetails
{
    public class GetWorkCenterDetailsQuery: IRequest<WorkCenterDetails>
    {
		public Guid Id { get; set; }
    }
}
