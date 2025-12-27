using Appo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appo.Persistence.Configurations
{
	internal class CompanyConfig: IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.Property(p => p.Name)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(p => p.Description)
				.HasMaxLength(250);
		}
	}

}
