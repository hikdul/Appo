using Appo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appo.Persistence.Configurations
{
    public class AppoimentConfig: IEntityTypeConfiguration<Appoiment>
    {
		public void Configure(EntityTypeBuilder<Appoiment> builder)
		{
			builder.Property(x => x.Gossip)
				.HasMaxLength(1500);

			builder.Property(x => x.WorkDescription)
				.HasMaxLength(1500);

			builder.Property(x => x.CustomerRequest)
				.HasMaxLength(254);
		}
    }
} 
