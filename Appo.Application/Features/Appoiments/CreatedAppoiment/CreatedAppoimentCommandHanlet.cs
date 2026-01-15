using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;
using Appo.Core.Builders;

namespace Appo.Application.Features.Appoiments.CreatedAppoiment
{
    public class CreatedAppoimentCommandHanlet: IRequestHandler<CreatedAppoimentCommand>
    {
        private readonly IRepositoryAppoiment repository;
        private readonly IUnitOfWork unitOfWork;

		public CreatedAppoimentCommandHanlet(IRepositoryAppoiment _repo, IUnitOfWork _uw)
		{
		    this.repository = _repo;
			this.unitOfWork = _uw;
		}

        public async Task Handle(CreatedAppoimentCommand command)
		{
			try
			{
				var appo = AppoimentBuilder.Create(command.CustomerId, command.Start, command.Finish);

				if(string.IsNullOrWhiteSpace(command.CustomerRequest))
					appo.WithCustomerRequest(command.CustomerRequest);

				if(command.PartnerId != null && command.PartnerId != Guid.Empty)
					appo.WithWorker((Guid)command.PartnerId);

				await repository.Add(appo.Build());
				await unitOfWork.Commit();
			}
			catch (System.Exception)
			{
				await unitOfWork.Rollback();
				throw;
			}




		}
	}
}
