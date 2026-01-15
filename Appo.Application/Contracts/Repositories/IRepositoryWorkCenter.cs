using Appo.Aplication.Contracts.Repositories;
using Appo.Application.Utilities.Pagination;
using Appo.Core.Entities;

namespace Appo.Application.Contracts.Repositories
{
    public interface IRepositoryWorkCenter: IRepository<WorkCenter>
    {
		Task<IEnumerable<WorkCenter>> GetFilter(FilterPagination filter);
    }
}
