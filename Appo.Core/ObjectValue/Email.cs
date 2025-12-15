
using System.Text.RegularExpressions;
using Appo.Core.Exceptions;

namespace Appo.Core.ObjectValues
{
	public record Email
	{
		public string Value { get; }

		public Email(string email)
		{

			if(string.IsNullOrEmpty(email))
				throw new BusinesRuleException($"The {nameof(email)} is required");
			if(!validateEmmailRegex(email))
				throw new BusinesRuleException($"The {nameof(email)} is not a valid email");

			this.Value = email;
		}


		protected bool validateEmmailRegex(string email)
		{
			string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
			return Regex.IsMatch(email, pattern);
		}

	}
}
