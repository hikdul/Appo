using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Contracts.Repositories;
using Appo.Aplication.Exceptions;
using Appo.Core.Entities;
using Appo.Aplication.Utilities.Mediator;
using Appo.Application.Contracts.Identity;

namespace Appo.Aplication.Features.Companys.Commands
{
    public class CreateCompanyCommandHandle: IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly IRepositoryCompany repository;
        private readonly IUnitOfWork unitOfWork;
		private readonly IUsersServices usersService;
		private readonly ITenantServices tenantServices;

        public CreateCompanyCommandHandle(
            IRepositoryCompany _repository,
            IUnitOfWork _unitOfWork,
			IUsersServices _us,
			ITenantServices _ts
        )
        {
            this.repository = _repository;
            this.unitOfWork = _unitOfWork;
			this.usersService = _us;
			this.tenantServices = _ts;
        }

        public async Task<Guid> Handle(CreateCompanyCommand command)
        {
            try
            {
                var ent = new Company(command.Name, command.Description);
                var resp = await repository.Add(ent);

				var userActive = usersService.GetUserId();
				await tenantServices.ChangeTenantUser(ent.Id, userActive);

                await unitOfWork.Commit();
                return resp.Id;
            }
            catch (System.Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }
        }
    }
}
