using Appo.Application.Contracts.Repositories;
using Appo.Core.Entities;
using CleanTeeth.Persistence.Repositories;

namespace Appo.Persistence.Repositories
{
    public class AppoimentRepository: Repository<Appoiment>, IRepositoryAppoiment
    {
		public AppoimentRepository(AppoDBContext _context): base(_context)
		{
		}
    }
}
