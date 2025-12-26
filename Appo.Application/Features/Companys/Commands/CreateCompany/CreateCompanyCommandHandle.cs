using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Appo.Aplication.Contracts.Persistence;
using Appo.Aplication.Contracts.Repositories;
using Appo.Aplication.Exceptions;
using Appo.Core.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Appo.Aplication.Features.Companys.Commands
{
    public class CreateCompanyCommandHandle
    {
        private readonly IRepositoryCompany repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly FluentValidation.IValidator<CreateCompanyCommand> validator;

        public CreateCompanyCommandHandle(
            IRepositoryCompany _repository,
            IUnitOfWork _unitOfWork,
            FluentValidation.IValidator<CreateCompanyCommand> _validator
        )
        {
            this.repository = _repository;
            this.unitOfWork = _unitOfWork;
            this.validator = _validator;
        }

        public async Task<Guid> Handle(CreateCompanyCommand command)
        {
            try
            {
                var _validationResult = await validator.ValidateAsync(command); 
                if (!_validationResult.IsValid)
                {
                    throw new AppoValidationException(_validationResult);
                }

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
