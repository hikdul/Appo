namespace Appo.API.DTOs
{
    public class Appoiment_in
    {
    	public DateTime Start { get; set; }
    	public DateTime Finish { get; set; }
		public Guid CustomerId { get; set; }
		public Guid? PartnerId { get; set; }
		public string? CustomerRequest { get; set; }
    }
}
