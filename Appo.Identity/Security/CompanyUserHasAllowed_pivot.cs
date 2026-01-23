namespace Appo.Identity.Security
{
    public class CompanyUserHasAllowed_pivot
    {

        public string UserId { get; set; } = null!;
        public Guid CompanyId { get; set; }
        public Alloweds Alloweds { get; set; }
        //public IdentityUser? Usuario { get; set; } //?: racionalmente desde aca no necesito estos datos
        //public Company? Company { get; set; } //?: racionalmente desde aca no necesito estos datos

    }
}
