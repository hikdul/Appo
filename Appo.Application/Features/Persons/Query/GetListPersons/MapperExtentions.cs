using Appo.Core.Entities;

namespace Appo.Application.Features.Persons.Query.GetListPersons
{
	public static class MapperExtentions
	{
		public static Persons_out Dto(this Person person)
		{
			return new() {

				Id = person.Id, 
				Name = person.Name,
				LastName  = person.LastName,
				Email  = person.Email.Value,
				PhoneNumber  = person.PhoneNumber.Value
			};
		}
	}
}
