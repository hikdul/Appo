using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;

namespace Appo.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHanle: IRequestHandler<CreatePersonCommand, Guid>
    {

        private readonly IRepositoryPerson repository;
        private readonly IUnitOfWork unitOfWork;

		public CreatePersonCommandHanle(IRepositoryPerson _repository, IUnitOfWork _uow)
		{
			this.repository = _repository;
			this.unitOfWork = _uow;
		}

		public async Task<Guid> Handle(CreatePersonCommand command)
		{

			var p = new Core.Entities.Person(command.Name, command.LastName, command.Email, command.PhoneNumber);

			await repository.Add(p);
			await unitOfWork.Commit();

			return p.Id;

		}
    }
}
