using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;
using Appo.Application.Utilities.Pagination;

namespace Appo.Application.Features.WorkCenter.Querys.GetListWorkCenter
{
    public class GetListWorkCenterQueryHandle: IRequestHandler<GetListWorkCenterQuery, PaginationDTO<WorkCenter_out>>
    {
		private readonly IRepositoryWorkCenter repository;
		public GetListWorkCenterQueryHandle(IRepositoryWorkCenter _repository)
		{
			this.repository = _repository;
		}


		public async Task<PaginationDTO<WorkCenter_out>> Handle(GetListWorkCenterQuery query)
		{
			 var ents = await repository.GetFilter(query);
			 var total = await repository.GetTotalAmountOfRecords();
			 var dtos = ents.Select(ent => ent.Dto()).ToList();
			PaginationDTO<WorkCenter_out> response = new() {
				 totalElements = total,
				 Elements = dtos
			 };

			return response;
		}
    }
}
