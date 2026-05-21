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
        
        builder.HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer() { Id = 1, Abbreviation = "Dell", FullName = "Dellington Industries", FoundationDate = DateOnly.Parse("2009-01-01")},
            new ComponentManufacturer() { Id = 2, Abbreviation = "AMD", FullName = "Alittle More Dell Industries", FoundationDate = DateOnly.Parse("2008-02-02")},
            new ComponentManufacturer() { Id = 3, Abbreviation = "R", FullName = "Rock Industries", FoundationDate = DateOnly.Parse("1980-01-01")},
        });
        
        builder.ToTable("ComponentManufacturers");
    }
}