using Appo.Aplication.Contracts.Repositories;
using Appo.Core.Entities;

namespace Appo.Application.Contracts.Repositories
{

	public interface IRepositoryPerson: IRepository<Person>
	{
	//	Task<Guid> FindOrCreated(Person entity); // se elimina pues al final ya esta todo listo nada mas de usa.. sin embargo si se deja el feature
	}
}
