using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;
using Appo.Core.Entities;

namespace Appo.Application.Features.Persons.Commands.FindOrCreated
{
	public class FindOrCreatedCommandHanle: IRequestHandler<FindOrCreatedCommand, Person>
	{

		private readonly IRepositoryPerson repository;
		private readonly IUnitOfWork unitOfWork;

		public FindOrCreatedCommandHanle(IRepositoryPerson _repo, IUnitOfWork _uow)
		{
			this.repository = _repo;
			this.unitOfWork = _uow;
		}

		public async Task<Person> Handle(FindOrCreatedCommand command)
		{

			Person person = await repository.FindOrCreated(command.Name, command.LastName, command.Email, command.PhoneNumber);

			if(person == null)
			{
				person = new Person(command.Name, command.LastName, command.Email, command.PhoneNumber);
				await unitOfWork.Commit();
			}
			return person;

		}
	}
}
