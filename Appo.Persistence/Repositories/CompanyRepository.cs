
using Appo.Aplication.Contracts.Repositories;
using Appo.Core.Entities;
using Appo.Persistence;

namespace CleanTeeth.Persistence.Repositories
{
	public class CompanyRepository: Repository<Company>, IRepositoryCompany
	{
		public CompanyRepository(AppoDBContext context): base(context)
		{

		}

	}
}
