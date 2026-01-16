namespace Appo.Application.Features.Appoiments.Querys.GetListAppoiment
{
    public class FilterAppoimentDTO
    {
		public Guid? CustomerId { get; set; }
		public Guid? PartnerId { get; set; }
		public Guid? WorkCenterId { get; set; }
		public DateTime Start { get; set; }
		public DateTime Finish { get; set; }
    }
}
