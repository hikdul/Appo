using Appo.Core.ObjectValues;

namespace Appo.Application.Features.WorkCenter.Querys.GetWorkCenterDetails
{
    public class WorkCenterDetails
    {
		public Guid Id { get; set; }
		public string Name { get;  set; }
        public string Direction { get;  set; }
        public int Latitud { get;  set; }
        public int Longitud { get;  set; }
    }

}
