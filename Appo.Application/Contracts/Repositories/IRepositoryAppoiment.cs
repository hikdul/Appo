using Appo.Aplication.Contracts.Repositories;
using Appo.Application.Features.Appoiments.Querys.GetListAppoiment;
using Appo.Core.Entities;

namespace Appo.Application.Contracts.Repositories
{
    public interface IRepositoryAppoiment: IRepository<Appoiment>
    {
		//TODO: Verificar que no exista una cita que ya exista
		Task<IEnumerable<Appoiment>> GetFilter(FilterAppoimentDTO filter);
    }
}
