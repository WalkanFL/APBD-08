using APBD_08.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_08.Configurations;

public class ComponentTypeConfiguration: IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.HasKey(ct => ct.Id);

        builder.Property(ct => ct.Abbreviation).HasMaxLength(30).IsRequired();
        
        builder.Property(ct => ct.Name).HasMaxLength(150).IsRequired();
        
        builder.ToTable("ComponentTypes");
    }
}