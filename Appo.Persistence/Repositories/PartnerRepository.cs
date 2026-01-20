using Appo.Application.Contracts.Repositories;
using Appo.Core.Entities;
using CleanTeeth.Persistence.Repositories;

namespace Appo.Persistence.Repositories
{
	public class PartnerRepository: Repository<Partner>, IRepositoryPartner
	{

		public PartnerRepository(AppoDBContext _context): base(_context)
		{

		}
	}
}
