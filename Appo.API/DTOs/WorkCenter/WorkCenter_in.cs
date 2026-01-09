namespace Appo.API.DTOs.WorkCenter
{
	public class WorkCenter_in
	{
		public string Name { get; set; }
		public string Direction { get; set; } = string.Empty;
		public int Latitud { get; set; } = 0;
		public int Longitud { get; set; } = 0;
	}
}
