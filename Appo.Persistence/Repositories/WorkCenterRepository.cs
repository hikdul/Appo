using Appo.Application.Contracts.Repositories;
using Appo.Core.Entities;
using CleanTeeth.Persistence.Repositories;

namespace Appo.Persistence.Repositories
{
	public class WorkCenterRepository: Repository<WorkCenter>, IRepositoryWorkCenter
	{
		public WorkCenterRepository(AppoDBContext context): base(context)
		{

		}
	}
}
