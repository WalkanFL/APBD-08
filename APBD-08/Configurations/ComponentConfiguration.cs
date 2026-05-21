using APBD_08.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_08.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(c => c.Code);
        builder.Property(c => c.Code).HasColumnType("char(10)").IsRequired();

        builder.Property(c => c.Name).HasMaxLength(300).IsRequired();
        
        builder.Property(c => c.Description).HasColumnType("nvarchar(max)").IsRequired();
        //fk
        builder
            .HasOne(c => c.ComponentManufacturer)
            .WithMany(cm => cm.Components)
            .HasForeignKey(c => c.ComponentManufacturersId)
            .OnDelete(DeleteBehavior.Cascade);
        //fk
        builder
            .HasOne(c => c.ComponentType)
            .WithMany(ct => ct.Components)
            .HasForeignKey(c => c.ComponentTypesId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new List<Component>()
        {
            new Component() { Code = "#000000000", Name = "Computator", Description = "first ever computational component EVER", ComponentManufacturersId = 3, ComponentTypesId = 2},
            new Component() { Code = "#000000001", Name = "Graphicler", Description = "seeing is believing", ComponentManufacturersId = 1, ComponentTypesId = 1},
            new Component() { Code = "#000000010", Name = "The Thinker", Description = "hmmm, hmmmmmm", ComponentManufacturersId = 2, ComponentTypesId = 3}
            
        });
        
        builder.ToTable("Components");
    }
}