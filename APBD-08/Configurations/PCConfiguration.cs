using APBD_08.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_08.Configurations;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(50).IsRequired();

        builder.Property(p => p.Weight).HasColumnType("float(5)").IsRequired();
        
        builder.Property(p => p.CreatedAt).HasColumnType("datetime").IsRequired();

        builder.HasData(new List<PC>()
        {
            new PC() { Id = 1, Name = "Preturbator", Weight = 50.5f, Warranty = 1, CreatedAt = DateTime.Parse("2026-05-07"), Stock = 10},
            new PC() { Id = 2, Name = "Respirat0004", Weight = 79.9f, Warranty = 3, CreatedAt = DateTime.Parse("2024-05-07"), Stock = 4},
            new PC() { Id = 3, Name = "Lapek", Weight = 7.5f, Warranty = 2, CreatedAt = DateTime.Parse("2077-05-07"), Stock = 10}
            
        });
        
        builder.ToTable("PCs");
    }
}