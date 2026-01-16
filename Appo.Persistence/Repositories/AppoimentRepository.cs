using Appo.Application.Contracts.Repositories;
using Appo.Application.Features.Appoiments.Querys.GetListAppoiment;
using Appo.Core.Entities;
using CleanTeeth.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Appo.Persistence.Repositories
{
	public class AppoimentRepository: Repository<Appoiment>, IRepositoryAppoiment
	{
		private readonly AppoDBContext context;
		public AppoimentRepository(AppoDBContext _context): base(_context)
		{
			this.context = _context;
		}

		public async Task<IEnumerable<Appoiment>> GetFilter(FilterAppoimentDTO filter)
		{
			var querable = this.context.Appoiments
				.Include(x => x.Customer).ThenInclude(x => x.Person)
				.Include(x => x.Partner).ThenInclude(x => x.Person)
				.Include(x => x.WorkCenter)
				.AsQueryable();

			if(filter.CustomerId is not null)
				querable = querable.Where(x => x.CustomerId == filter.CustomerId);

			if(filter.PartnerId is not null)
				querable = querable.Where(x => x.PartnerId == filter.PartnerId);

			if(filter.WorkCenterId is not null)
				querable = querable.Where(x => x.WorkCenterId == filter.WorkCenterId);

			return await  querable.Where(x => x.TimeInterval.Start >= filter.Start 
					&& x.TimeInterval.Finish < filter.Finish)
				.ToListAsync();

		}

	}
}
