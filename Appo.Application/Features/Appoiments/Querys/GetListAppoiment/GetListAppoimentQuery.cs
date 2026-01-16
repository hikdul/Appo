using Appo.Aplication.Utilities.Mediator;

namespace Appo.Application.Features.Appoiments.Querys.GetListAppoiment
{
    public class GetListAppoimentQuery: FilterAppoimentDTO, IRequest<List<Appoiment_list>>
    {
    }
}
