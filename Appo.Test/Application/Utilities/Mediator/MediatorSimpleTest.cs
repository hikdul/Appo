using Appo.Aplication.Exceptions;
using Appo.Aplication.Utilities;
using Appo.Aplication.Utilities.Mediator;
using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTeeth.Tests.Application.Utilities.Mediator
{
    [TestClass]
    public class MediatorSimpleTest
    {
        public class FalseRequest : IRequest<string>
        {
            public required string Name { get; set; }
        }

        public class FalseRequestValidator : AbstractValidator<FalseRequest>
        {
            public FalseRequestValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }

        [TestMethod]
        public async Task Send_WithRegisteredHandler_HandleIsExecuted()
        {
            var request = new FalseRequest() { Name = "Example" };

            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();

            var serviceProvider = Substitute.For<IServiceProvider>();

            serviceProvider
            .GetService(typeof(IRequestHandler<FalseRequest, string>))
            .Returns(handlerMock);

            var mediator = new MediatorSimple(serviceProvider);

            var result = await mediator.Send(request);

            await handlerMock.Received(1).Handle(request);

        }

		// TODO:  Generar las pruebas para los casos de falla.
		/*

        [TestMethod]
        [ExpectedException(typeof(MediatorException))]
        public async Task Send_WithoutRegisteredHandler_Throws()
        {
            var request = new FalseRequest() { Name = "Example"};
            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>))
                .ReturnsNull();

            var mediator = new MediatorSimple(serviceProvider);

            var result = await mediator.Send(request);
        }

        [TestMethod]
        [ExpectedException(typeof(CustomValidationException))]
        public async Task Send_InvalidCommand_Throws()
        {
            var request = new FalseRequest() { Name = "" };
            var serviceProvider = Substitute.For<IServiceProvider>();
            var validator = new FalseRequestValidator();

            serviceProvider
                .GetService(typeof(IValidator<FalseRequest>))
                .Returns(validator);

            var mediator = new MediatorSimple(serviceProvider);

            await mediator.Send(request);

        }
		*/

    }
}
