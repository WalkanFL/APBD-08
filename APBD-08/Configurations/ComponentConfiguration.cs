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
            .HasForeignKey(c => c.ComponentManufacturerId)
            .OnDelete(DeleteBehavior.Cascade);
        //fk
        builder
            .HasOne(c => c.ComponentType)
            .WithMany(ct => ct.Components)
            .HasForeignKey(c => c.ComponentTypeId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new List<Component>()
        {
            new Component() { Code = "#000000000", Name = "Computator", Description = "first ever computational component EVER", ComponentManufacturerId = 3, ComponentTypeId = 2},
            new Component() { Code = "#000000001", Name = "Graphicler", Description = "seeing is believing", ComponentManufacturerId = 1, ComponentTypeId = 1},
            new Component() { Code = "#000000010", Name = "The Thinker", Description = "hmmm, hmmmmmm", ComponentManufacturerId = 2, ComponentTypeId = 3}
            
        });
        
        builder.ToTable("Components");
    }
}