using Appo.Core.Exceptions;
using System.Text.RegularExpressions;

namespace Appo.Core.ObjectValues
{
	public record PhoneNumber
	{
		public string Value { get; }

		private PhoneNumber(){}

		public PhoneNumber(string phoneNumber)
		{
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new BusinesRuleException($"The {nameof(PhoneNumber)} is required ");
            }

            if (!validatePhoneNumberRegex(phoneNumber))
            {
                throw new BusinesRuleException(
                    $"The entry is no a valid PhoneNumber."
                );
            }

            this.Value = phoneNumber;
		}

		//TODO: Validar este para que dependiendo del pais valide segun el formato.
        private bool validatePhoneNumberRegex(string PhoneNumber)
        {
            string pattern = @"^\d+$";
            return Regex.IsMatch(PhoneNumber, pattern);
        }
	}
}
