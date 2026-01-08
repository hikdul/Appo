
using Appo.Aplication.Utilities.Mediator;
using Appo.Aplication.Contracts.Repositories;
using System.Linq;

namespace Appo.Aplication.Features.Companys.Querys
{
	public class GetListCompanyQueryHanlet: IRequestHandler<GetListCompanysQuery, List<CompanyOut>>
	{

		private readonly IRepositoryCompany repository;

		public GetListCompanyQueryHanlet(IRepositoryCompany _repository)
		{
			this.repository = _repository;   
		}


		public async Task<List<CompanyOut>> Handle(GetListCompanysQuery request)
		{
			var ent = await repository.GetAll();
            var dto = ent.Select(ent => ent.Dto()).ToList();
            return dto;
		}

	}
}
