namespace Appo.Core.Commons
{
    public abstract class AuditEnt
    {
		public string? CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public string? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }

    }
}
