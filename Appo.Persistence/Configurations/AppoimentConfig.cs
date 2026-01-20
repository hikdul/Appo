using Appo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appo.Persistence.Configurations
{
    public class AppoimentConfig: IEntityTypeConfiguration<Appoiment>
    {
		public void Configure(EntityTypeBuilder<Appoiment> builder)
		{
            builder.ComplexProperty(prop => prop.TimeInterval, action =>
            {
                action.Property(e => e.Start).HasColumnName("Start");
                action.Property(e => e.Finish).HasColumnName("Finish");
            });

			builder.Property(x => x.CustomerRequest)
				.HasMaxLength(254);
		}
    }
} 
