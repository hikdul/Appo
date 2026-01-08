
using Appo.Aplication.Utilities.Mediator;
using Appo.Core.ObjectValues;

namespace Appo.Application.Features.WorkCenter.Commands.CreateWorkCenter
{
    public class CreateWorkCenterCommand: IRequest
    {
		public string Name { get; set; }
		public Direction? Direction { get; set; }
    }
}
