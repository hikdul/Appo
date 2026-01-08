using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Contracts.Repositories;
using Appo.Aplication.Utilities.Mediator;

namespace Appo.Application.Features.WorkCenter.Commands.CreateWorkCenter
{
	public class CreateWorkCenterComandHanler: IRequestHandler<CreateWorkCenterCommand>
	{
		private readonly IRepositoryCompany repository;
		private readonly IUnitOfWork unitOfWork;

		public CreateWorkCenterComandHanler(
				IRepositoryCompany _repository,
				IUnitOfWork _unitOfWork
				)
		{
			this.repository = _repository;
			this.unitOfWork = _unitOfWork;
		}

		public async Task Handle(CreateWorkCenterCommand command)
		{
			try
			{
				var ent = new Core.Entities.WorkCenter(command.Name, command.Direction);
				var resp = await repository.Add(ent);
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
