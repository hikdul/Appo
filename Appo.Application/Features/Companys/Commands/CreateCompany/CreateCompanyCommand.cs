
namespace Appo.Aplication.Features.Companys.Commands
{
    public class CreateCompanyCommand
    {
		public required string Name { get; set; }
		public string? Description { get; set; }
    }
}
