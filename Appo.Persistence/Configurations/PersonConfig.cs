using Appo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appo.Persistence.Configurations
{
	public class PersonConfig: IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.Property(p => p.Name)
				.HasMaxLength(250)
				.IsRequired();

			builder.Property(p => p.LastName)
				.HasMaxLength(250);

			builder.ComplexProperty(prop => prop.Email, action => 
					{
					action.Property(e => e.Value).HasColumnName("Email").HasMaxLength(254);
					});

			builder.ComplexProperty(prop => prop.PhoneNumber, action =>
					{
					action.Property(e => e.Value).HasColumnName("PhoneNumber").HasMaxLength(254);
					});
		}
	}
}

