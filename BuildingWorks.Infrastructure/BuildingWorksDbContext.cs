using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Plans;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Infrastructure;

public class BuildingWorksDbContext : DbContext
{
    public DbSet<BuildingObject> BuildingObjects { get; set; } = null!;
    public DbSet<Provider> Providers { get; set; } = null!;
    public DbSet<Material> Materials { get; set; } = null!;
    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<Worker> Workers { get; set; } = null!;
    public DbSet<WorkerSalary> WorkerSalaries { get; set; } = null!;
    public DbSet<Plan> Plans { get; set; } = null!;
    public DbSet<BrigadeWorker> BrigadeWorker { get; set; } = null!;

    public BuildingWorksDbContext() { }
    public BuildingWorksDbContext(DbContextOptions<BuildingWorksDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureEntities();
    }
}