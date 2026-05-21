using APBD_08.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_08.Configurations;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        builder.HasKey(pcc => new { pcc.PCId, pcc.ComponentCode });
        //FK
        builder
            .HasOne(pcc => pcc.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(pcc => pcc.PCId)
            .OnDelete(DeleteBehavior.Cascade);
        //FK
        builder
            .HasOne(pcc => pcc.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(pcc => pcc.ComponentCode)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new List<PCComponent>()
        {
            new PCComponent() { PCId = 1, ComponentCode = "#000000000", Amount = 1},
            new PCComponent() { PCId = 1, ComponentCode = "#000000001", Amount = 1},
            new PCComponent() { PCId = 1, ComponentCode = "#000000010", Amount = 1},
            
            new PCComponent() { PCId = 2, ComponentCode = "#000000000", Amount = 1},
            new PCComponent() { PCId = 2, ComponentCode = "#000000001", Amount = 1},
            new PCComponent() { PCId = 2, ComponentCode = "#000000010", Amount = 16},

        });
        
        builder.ToTable("PCComponents");
    }
}