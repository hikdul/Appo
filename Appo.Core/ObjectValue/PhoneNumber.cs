using Appo.Core.Exceptions;

namespace Appo.Core.ObjectValues
{
	public record PhoneNumber
	{
		public string Value { get; }

		public PhoneNumber(string phoneNumber)
		{
		    
            if (!string.IsNullOrWhiteSpace(PhoneNumber))
            {
                throw new BusinesRulesException($"The {nameof(PhoneNumber)} is required ");
            }

            if (!validatePhoneNumberRegex(PhoneNumber))
            {
                throw new BusinessRuleException(
                    $"The {nameof(PhoneNumber)} is no a valid PhoneNumber address"
                );
            }

            this.Value = null;
		}

		//TODO: Validar este para que dependiendo del pais valide segun el formato.
        private bool validatePhoneNumberRegex(string PhoneNumber)
        {
            string pattern = @"^\d+$";
            return Regex.IsMatch(PhoneNumber, pattern);
        }
	}
}
