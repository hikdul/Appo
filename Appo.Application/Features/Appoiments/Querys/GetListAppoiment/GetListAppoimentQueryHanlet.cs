using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;

namespace Appo.Application.Features.Appoiments.Querys.GetListAppoiment
{
    public class GetListAppoimentQueryHanlet: IRequestHandler<GetListAppoimentQuery,List<Appoiment_list>>
    {
		private readonly IRepositoryAppoiment repository;
		public GetListAppoimentQueryHanlet(IRepositoryAppoiment _repository)
		{
		    this.repository = _repository;
		}

		public async Task<List<Appoiment_list>> Handle(GetListAppoimentQuery query)
		{
			var ents = await repository.GetFilter(query);
			var dtos = ents.Select(c => c.Dto()).ToList();
			return dtos;
		}
    }
}
