using Appo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appo.Persistence.Configurations
{
    public class CustomerConfig: IEntityTypeConfiguration<Customer>
    {
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.HasKey(x => new {
					x.TenantId,
					x.PersonId
					});
		}
    }
}
