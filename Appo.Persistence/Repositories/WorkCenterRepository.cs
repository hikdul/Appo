using Appo.Application.Contracts.Repositories;
using Appo.Application.Utilities.Pagination;
using Appo.Core.Entities;
using Appo.Persistence.Utils.Pagination;
using CleanTeeth.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Appo.Persistence.Repositories
{
	public class WorkCenterRepository: Repository<WorkCenter>, IRepositoryWorkCenter
	{
		private readonly AppoDBContext context;

		public WorkCenterRepository(AppoDBContext _context): base(_context)
		{
			this.context = _context;
		}

		public async Task<IEnumerable<WorkCenter>> GetFilter(FilterPagination filter)
		{
			return await context.WorkCenters
				.OrderBy(x => x.Name)
				.Pagination(filter.CurrentPage, filter.MaxRegisterPerPage)
				.ToListAsync();
		}
	}
}
