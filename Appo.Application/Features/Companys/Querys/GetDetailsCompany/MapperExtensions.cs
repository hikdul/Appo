
using Appo.Core.Entities;

namespace Appo.Aplication.Features.Companys.Querys
{
	public static class MapperExtensions
	{
		public static CompanyOut ToDto(this Company company)
		{
			 var dto = new CompanyOut { Name = company.Name, Description = company.Description, Id = company.Id };

			 return dto;
		}
	}
}
