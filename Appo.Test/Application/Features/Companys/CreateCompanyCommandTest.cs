using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;
using FluentValidation;
using FluentValidation.Results;

using Appo.Aplication.Features.Companys.Commands;
using Appo.Aplication.Exceptions;
using Appo.Core.Entities;
using Appo.Aplication.Contracts.Repositories;
using Appo.Aplication.Contracts.Persistence;

namespace Appo.Test.Features
{
	//TODO: generar resto de test para este elemento

	[TestClass]
	public class CreateCompanyCommandTest
	{

		// note: con esto evitamos los warning que puede ser un fastidio
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
		private IRepositoryCompany repository;
		private IUnitOfWork unitOfWork;
		private CreateCompanyCommandHandle feature;
		private FluentValidation.IValidator<CreateCompanyCommand> validator;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

		[TestInitialize]
		public void Setup()
		{
			repository = Substitute.For<IRepositoryCompany>();
			unitOfWork = Substitute.For<IUnitOfWork>();
			validator = Substitute.For<FluentValidation.IValidator<CreateCompanyCommand>>();

			feature = new CreateCompanyCommandHandle(repository, unitOfWork);
		}

		[TestMethod]
		public async Task ValidCommand_whitNotDescription()
		{
			string name = Guid.NewGuid().ToString();
			var command = new CreateCompanyCommand{Name = name};

			validator.ValidateAsync(command).Returns(new ValidationResult());
			var buildCompany = new Company(name, null);
			repository.Add(Arg.Any<Company>()).Returns(buildCompany);

			var result = await feature.Handle(command);

			await repository.Received(1).Add(Arg.Any<Company>());
			await unitOfWork.Received(1).Commit();
			Assert.AreNotEqual(Guid.Empty, result);

		}

	}
}
