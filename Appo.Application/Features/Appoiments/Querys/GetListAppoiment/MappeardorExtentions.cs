using Appo.Core.Entities;

namespace Appo.Application.Features.Appoiments.Querys.GetListAppoiment
{
	public static class MappeardorExtentions
	{
		public static Appoiment_list Dto(this Appoiment appo)
		{
			return  new Appoiment_list{

				Start  =  appo.TimeInterval.Start,
				Finish  = appo.TimeInterval.Finish,
				Customer  = appo.Customer.Person != null ?  $"{appo.Customer.Person.Name} {appo.Customer.Person.LastName}": "",
				Partner   = appo?.Partner?.Person != null ?  $"{appo.Customer?.Person?.Name} {appo.Customer?.Person?.LastName}": "",
				WorkCenter = appo?.WorkCenter?.Name ?? "",
				Status = appo.Status.ToString(),
				CustomerRequest  = appo.CustomerRequest,
				WorkDescription  = appo.WorkDescription,
				Gossip = appo.Gossip
			};
		}
	}
}
