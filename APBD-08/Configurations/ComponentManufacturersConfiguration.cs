using APBD_08.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_08.Configurations;

public class ComponentManufacturersConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.HasKey(cm => cm.Id);

        builder.Property(cm => cm.Abbreviation).HasMaxLength(30).IsRequired();
        
        builder.Property(cm => cm.FullName).HasMaxLength(300).IsRequired();
        
        builder.Property(cm => cm.FoundationDate).HasColumnType("date").IsRequired();
        
        builder.ToTable("ComponentManufacturers");
    }
}