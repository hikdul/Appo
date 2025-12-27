using Appo.Aplication.Contracts.Repositories;
using Appo.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanTeeth.Persistence.Repositories
{
	///<summary>
	/// implementacion de los elementos genericos de todos los cruds
	///</summary>
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppoDBContext context;

		public Repository(AppoDBContext _context)
		{
			this.context = _context;
		}

		public Task<T> Add(T entity)
		{
			context.Add(entity);
			return Task.FromResult(entity);
		}

		public Task Delete(T entity)
		{
			context.Remove(entity);
			return Task.CompletedTask;
		}

		public async Task<IEnumerable<T>> GetAll()
		{
			return await context.Set<T>().ToListAsync();
		}

		public async Task<T?> GetById(Guid id)
		{
			return await context.Set<T>().FindAsync(id);
		}

		public async Task<int> GetTotalAmountOfRecords()
		{
			return await context.Set<T>().CountAsync();
		}

		public Task Update(T entity)
		{
			context.Update(entity);
			return Task.CompletedTask;
		}
	}
}
