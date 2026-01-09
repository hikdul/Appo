namespace Appo.Application.Features.Persons.Query.GetListPersons
{
    public class Persons_out
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; } //TODO: que el constructo valide que exista al menos 1 de las 2 para guardar los datos...
		public string? PhoneNumber { get; set; }
    }
}
