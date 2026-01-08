namespace Appo.API.DTOs.WorkCompany
{
	public class WorkCompany_in
	{
		public string Name { get; set; }
		public string Direction { get; set; } = string.Empty;
		public int Latitud { get; set; } = 0;
		public int Longitud { get; set; } = 0;
	}
}
