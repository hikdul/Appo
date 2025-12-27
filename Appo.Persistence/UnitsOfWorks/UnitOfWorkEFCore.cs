
using Appo.Aplication.Contracts.Persistence;
using Appo.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appo.Persistence.UnitsOfWorks
{
	///<summary>
	/// este patron se esta usando para las pruebas.. luego cambiar a Postgress
	///</summary>
	public class UnitOfWorkEFCore : IUnitOfWork
	{
		private readonly AppoDBContext context;

		public UnitOfWorkEFCore(AppoDBContext context)
		{
			this.context = context;
		}

		public async Task Commit()
		{
			await context.SaveChangesAsync();
		}

		public Task Rollback()
		{
			return Task.CompletedTask;
		}
	}
}
