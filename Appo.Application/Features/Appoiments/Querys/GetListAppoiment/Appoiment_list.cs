using Appo.Core.Helpers;

namespace Appo.Application.Features.Appoiments.Querys.GetListAppoiment
{
	public class Appoiment_list
	{
		public DateTime Start { get; set; }
		public DateTime Finish { get; set; }

		public string Customer { get;  set; }

		public string? Partner { get;  set; }

		public string? WorkCenter { get;  set; }

		public string Status { get;  set; }

		public string? CustomerRequest { get;  set; }

		public string? WorkDescription { get;  set; }
		// => esto es el chisme
		public string? Gossip { get;  set; }
	}
}
