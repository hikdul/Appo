using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;

namespace Appo.Application.Features.WorkCenter.Querys.GetListWorkCenter
{
    public class GetListWorkCenterQueryHandle: IRequestHandler<GetListWorkCenterQuery, List<WorkCenter_out>>
    {
		private readonly IRepositoryWorkCenter repository;
		public GetListWorkCenterQueryHandle(IRepositoryWorkCenter _repository)
		{
			this.repository = _repository;
		}


		public async Task<List<WorkCenter_out>> Handle(GetListWorkCenterQuery query)
		{
			 var response = await repository.GetAll();
			 return response.Select(r => r.Dto()).ToList();
		}
    }
}
