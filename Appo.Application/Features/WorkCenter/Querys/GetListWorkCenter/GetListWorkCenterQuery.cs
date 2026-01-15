using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Utilities.Pagination;

namespace Appo.Application.Features.WorkCenter.Querys.GetListWorkCenter
{
	//NOTA: que se hereda del filtro de paginacion y la respuesta va a ser el paginado
    public class GetListWorkCenterQuery: FilterPagination, IRequest<PaginationDTO<WorkCenter_out>>
    {
    }
}
