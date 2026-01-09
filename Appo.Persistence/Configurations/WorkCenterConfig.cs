using Appo.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Appo.Persistence.Configurations
{
	public class WorkCenterConfig: IEntityTypeConfiguration<WorkCenter>
	{
		public void Configure(EntityTypeBuilder<WorkCenter> builder)
		{
			builder.Property(p => p.Name)
				.HasMaxLength(200)
				.IsRequired();

			builder.ComplexProperty(p => p.Direction, action =>{
					action.Property(e => e.Value).HasColumnName("Direction").HasMaxLength(254);
					action.Property(e => e.Latitud).HasColumnName("Latitud");
					action.Property(e => e.Longitud).HasColumnName("Longitud");
					}); 
		}
	}

}
