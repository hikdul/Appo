
using Appo.Core.Exceptions;

namespace Appo.Core.ObjectValues
{
	public class Direction
	{

        public string Value { get; }
        public int Latitud { get; }
        public int Longitud { get; }

        protected Direction() { }

        public Direction(string Direction, int Latitud = 0, int Longitud = 0)
        {

            if (string.IsNullOrWhiteSpace(Direction))
                throw new BusinesRuleException("The Direction description is REQUIRED");
            if (Latitud < -90 || Latitud > 90)
                throw new BusinesRuleException("The Latitud value is not valid");
            if (Longitud < -180 || Longitud > 180)
                throw new BusinesRuleException("The Longitud value is not valid");

            this.Value = Direction;
            this.Latitud = Latitud;
            this.Longitud = Longitud;
        }
		
	}
}
