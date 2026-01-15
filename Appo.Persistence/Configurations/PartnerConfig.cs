using Appo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appo.Persistence.Configurations
{
    public class PartnerConfig: IEntityTypeConfiguration<Partner>
    {
		public void Configure(EntityTypeBuilder<Partner> builder)
		{
			builder.HasKey(x => new {
					x.TenantId,
					x.PersonId
					});
		}
    }
}
