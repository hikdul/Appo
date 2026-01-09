using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;

namespace Appo.Application.Features.Persons.Query.GetListPersons
{
    public class GetListPersonsQueryHanle: IRequestHandler<GetListPersonsQuery, List<Persons_out>>
    {

        private readonly IRepositoryPerson repository;
        private readonly IUnitOfWork unitOfWork;

		public GetListPersonsQueryHanle(IRepositoryPerson _repo, IUnitOfWork _uow)
		{
		    this.repository = _repo;
			this.unitOfWork = _uow;
		}

		public async Task<List<Persons_out>> Handle(GetListPersonsQuery query)
		{
			var ents = await repository.GetAll();
			return ents.Select(e => e.Dto()).ToList();
		}
    }
}
