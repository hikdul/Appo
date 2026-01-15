using Appo.Application.Contracts.Repositories;
using Appo.Core.Entities;
using CleanTeeth.Persistence.Repositories;

namespace Appo.Persistence.Repositories
{
    public class CustomerRepository: Repository<Customer>, IRepositoryCustomer
    {
		public CustomerRepository(AppoDBContext _context): base(_context)
		{
		}
    }
}
