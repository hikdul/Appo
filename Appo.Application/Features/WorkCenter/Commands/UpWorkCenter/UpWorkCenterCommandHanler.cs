using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Contracts.Repositories;
using Appo.Aplication.Exceptions;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Repositories;
using Appo.Core.ObjectValues;

namespace Appo.Application.Features.WorkCenter.Commands.UpWorkCenter
{
    public class UpWorkCenterCommandHanler: IRequestHandler<UpWorkCenterCommand>
    {

		private readonly IRepositoryWorkCenter repository;
		private readonly IUnitOfWork unitOfWork;

		public UpWorkCenterCommandHanler(IRepositoryWorkCenter _repository, IUnitOfWork _unitOfWork)
		{
		    this.repository = _repository;
			this.unitOfWork = _unitOfWork;
		}

		public async Task Handle(UpWorkCenterCommand command)
		{
			try
			{
				var ent = await repository.GetById(command.Id);
				Direction dir = null;
				if(string.IsNullOrEmpty(command.Direction ))
					dir = new( command.Direction, command.Latitud, command.Longitud);
				ent.Up(command.Name,dir);
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
