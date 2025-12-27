using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Contracts.Repositories;
using Appo.Aplication.Exceptions;
using Appo.Core.Entities;
using Appo.Aplication.Utilities.Mediator;

namespace Appo.Aplication.Features.Companys.Commands
{
    public class CreateCompanyCommandHandle: IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly IRepositoryCompany repository;
        private readonly IUnitOfWork unitOfWork;

        public CreateCompanyCommandHandle(
            IRepositoryCompany _repository,
            IUnitOfWork _unitOfWork
        )
        {
            this.repository = _repository;
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Guid> Handle(CreateCompanyCommand command)
        {
            try
            {
                var ent = new Company(command.Name, command.Description);
                var resp = await repository.Add(ent);
                unitOfWork.Commit();
                return resp.Id;
            }
            catch (System.Exception)
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
