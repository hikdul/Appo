using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Exceptions;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;

// TODO: Verificar la viabilidad de actualizar todo o de separar ciertos elementos por partes como el correo 

namespace Appo.Application.Features.Persons.Commands.UpdatePerson
{
	public class UpdatePersonCommandHanle: IRequestHandler<UpdatePersonCommand>
	{

		private readonly IRepositoryPerson repository;
		private readonly IUnitOfWork unitOfWork;

		public UpdatePersonCommandHanle(IRepositoryPerson _repo, IUnitOfWork _uow)
		{
			this.repository = _repo;
			this.unitOfWork = _uow;
		}

		public async Task Handle(UpdatePersonCommand command)
		{
			try
			{
				var ent = await repository.GetById(command.Id);

				if(ent is null)
					throw new NotFoundException();

				ent.Up(command.Name, command.LastName, command.Email, command.PhoneNumber);
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
