
using System.Text;
using Appo.Aplication.Utilities.Mediator;
using Appo.Aplication.Exceptions;
using Appo.Core.Entities;

namespace Appo.Aplication.Features.Companys.Querys
{
	public class GetDetailsCompanyQueryHandle: IRequestHandler<GetDetailsCompanyQuery, CompanyOut>
	{

        private readonly IRepositoryCompany repository;

		public GetDetailsCompanyQueryHandle(IRepositoryCompany _repository)
		{
		    this.repository = _repository;
		}
		
		public async Task<CompanyOut> Handle(GetDetailsCompanyQuery query)
		{
			 var response = await repository.GetById(query.Id);

			 if(response is null)
			 {
				 throw new NotFoundException();
			 }

			 response.ToDto();

		}
	}

}
