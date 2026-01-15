using Appo.Aplication.Contracts.Repositories;
using Appo.Application.Contracts.Repositories;
using Appo.Core.Entities;
using CleanTeeth.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Appo.Persistence.Repositories
{
	public class PersonRepository: Repository<Person>, IRepositoryPerson
	{

		private readonly AppoDBContext context;

		public PersonRepository(AppoDBContext _context): base(_context)
		{
			this.context = _context;
		}

		public async Task<Person> FindOrCreated(string Name, string? LastName ,	string? Email ,	string? PhoneNumber )
		{
			Person p = await context.Persons
				.Where(p =>  (p.Email != null && p.Email.Value != null && Email != null && p.Email.Value == Email) 
						|| (p.PhoneNumber != null && p.PhoneNumber.Value != null && PhoneNumber != null && p.PhoneNumber.Value == PhoneNumber))
				.FirstOrDefaultAsync();

			if (p is  null )
				p = new( Name, LastName, Email , PhoneNumber );

			return p;

		}


	}
}
