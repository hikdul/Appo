using Appo.Aplication.Contracts.Repositories;
using Appo.Application.Contracts.Repositories;
using Appo.Core.Entities;
using CleanTeeth.Persistence.Repositories;

namespace Appo.Persistence.Repositories
{
	public class PersonRepository: Repository<Person>, IRepositoryPerson
	{

		private readonly AppoDBContext context;

		public PersonRepository(AppoDBContext _context): base(_context)
		{
			this.context = _context;
		}

	}
}
