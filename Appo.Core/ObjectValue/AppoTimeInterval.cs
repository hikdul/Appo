
using System;
using Appo.Core.Exceptions;


namespace Appo.Core.ObjectValues
{
    public record AppoTimeInterval
    {
    	public DateTime Start { get; set; }
    	public DateTime Finish { get; set; }

		public AppoTimeInterval(DateTime start, DateTime finish)
		{
		    if(finish < start)
				throw new BusinesRuleException("The time interval is not valid");

			this.Start = start;
			this.Finish = finish;
		}
    }
}
