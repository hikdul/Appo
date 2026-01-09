using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;
using Appo.Core.Entities;

namespace Appo.Application.Features.Persons.Commands.FindOrCreated
{
	public class FindOrCreatedCommandHanle: IRequestHandler<FindOrCreatedCommand, Guid>
	{

		private readonly IRepositoryPerson repository;
		private readonly IUnitOfWork unitOfWork;

		public FindOrCreatedCommandHanle(IRepositoryPerson _repo, IUnitOfWork _uow)
		{
			this.repository = _repo;
			this.unitOfWork = _uow;
		}

		public async Task<Guid> Handle(FindOrCreatedCommand command)
		{
			if(Guid.Empty != command.Id)
			{
				var ent = await repository.GetById(command.Id);
				if(ent is not null)
					return command.Id;
			}

			var person = new Person(command.Name, command.LastName, command.Email, command.PhoneNumber);
			await unitOfWork.Commit();

			return person.Id;

		}
	}
}
