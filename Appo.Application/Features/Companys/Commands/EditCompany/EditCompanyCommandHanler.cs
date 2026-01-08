using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Contracts.Repositories;
using Appo.Aplication.Utilities.Mediator;
using Appo.Aplication.Exceptions;

namespace Appo.Aplication.Features.Companys.Commands
{
	public class EditCompanyCommandHanler: IRequestHandler<EditCompanyCommand>
	{

        private readonly IRepositoryCompany repository;
        private readonly IUnitOfWork unitOfWork;

		public EditCompanyCommandHanler(IRepositoryCompany _repository, IUnitOfWork _uow)
		{
		    this.repository = _repository;
			this.unitOfWork = _uow;
		}

		public async Task Handle(EditCompanyCommand request)
		{
            var ent = await repository.GetById(request.Id);

            if (ent is null)
            {
                throw new NotFoundException();
            }

			ent.Up(request.Name, request.Description);

            try
            {
                await repository.Update(ent);
                await unitOfWork.Commit();
            }
            catch (Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }
        }
		
	}
}
