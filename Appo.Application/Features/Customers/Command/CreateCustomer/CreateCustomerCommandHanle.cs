using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;
using Appo.Core.Entities;

namespace Appo.Application.Features.Customers.Command.CreateCustomer
{
    public class CreateCustomerCommandHanle: IRequestHandler<CreateCustomerCommand>
    {

        private readonly IRepositoryCustomer repository;
        private readonly IUnitOfWork unitOfWork;

		public CreateCustomerCommandHanle(IRepositoryCustomer _repository , IUnitOfWork _uow)
		{
			this.repository = _repository;
			this.unitOfWork = _uow;
		}

		public async Task Handle(CreateCustomerCommand command)
		{
			Customer ent = new(command.TenantId, command.PersonId);
			await repository.Add(ent);
			await unitOfWork.Commit();
		}
    }
}
