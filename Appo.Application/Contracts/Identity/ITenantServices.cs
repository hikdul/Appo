namespace Appo.Application.Contracts.Identity
{
    public interface ITenantServices
    {
		Task ChangeTenantUser(Guid CompanyId, string userid);
    }
}

