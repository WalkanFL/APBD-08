using APBD_08.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD_08.Data;

public class AppDBContext : DbContext
{
    protected AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions options) : base(options)
    {
    }
    
    DbSet<PC> PCs { get; set; }
    DbSet<Component> Components { get; set; }
    DbSet<PCComponent> PCComponents { get; set; }
    DbSet<ComponentType> ComponentTypes { get; set; }
    DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        
        //kończymy na bazie
        base.OnModelCreating(modelBuilder);
    }
}