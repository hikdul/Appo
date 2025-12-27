
using System.Text;
using Appo.Aplication.Utilities.Mediator;

namespace Appo.Aplication.Features.Companys.Querys
{
	public class GetDetailsCompanyQuery: IRequest<CompanyOut>
	{
		public Guid Id { get; set; }
	}

}
