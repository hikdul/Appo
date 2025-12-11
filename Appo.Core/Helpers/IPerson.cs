
namespace Appo.Core.Helpers
{
    public interface IPerson
    {
    	
		//public string Name { get; private set; }
		//public string? LastName { get; private set; }
		//public Email? Email { get; set; } 
		//public PhoneNumber? PhoneNumber { get; set; }

		void Up(string? name, string? lastName, string? email, string? phoneNumber);
    }
}
