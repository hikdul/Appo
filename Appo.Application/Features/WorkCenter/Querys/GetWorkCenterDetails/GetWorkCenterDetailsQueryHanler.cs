using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;
using Appo.Aplication.Exceptions;

namespace Appo.Application.Features.WorkCenter.Querys.GetWorkCenterDetails
{
	public class GetWorkCenterDetailsQueryHanler: IRequestHandler<GetWorkCenterDetailsQuery, WorkCenterDetails>
	{

		private readonly IRepositoryWorkCenter repository;

		public GetWorkCenterDetailsQueryHanler(IRepositoryWorkCenter _repository)
		{
			this.repository = _repository;
		}

		public async Task<WorkCenterDetails> Handle(GetWorkCenterDetailsQuery query)
		{
			var response = await repository.GetById(query.Id);

			if(response is null)
			{
				throw new NotFoundException();
			}

			return response.Dto();

		}
	}
}
