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
    
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        //kończymy na bazie
        base.OnModelCreating(modelBuilder);
    }
}