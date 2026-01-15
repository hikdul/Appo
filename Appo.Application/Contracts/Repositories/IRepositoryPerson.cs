using Appo.Aplication.Contracts.Repositories;
using Appo.Core.Entities;

namespace Appo.Application.Contracts.Repositories
{

	public interface IRepositoryPerson: IRepository<Person>
	{
		Task<Person> FindOrCreated( string Name, string? LastName ,	string? Email ,	string? PhoneNumber ); 
	}
}
