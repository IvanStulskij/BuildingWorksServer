using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;
using BuildingWorks.Infrastructure.Entities.Plans;
using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;
using Microsoft.EntityFrameworkCore;

namespace BuildingWorks.Infrastructure;

public class BuildingWorksDbContext : DbContext
{
    public virtual DbSet<BuildingObject> BuildingObjects { get; set; } = null!;
    public virtual DbSet<Provider> Providers { get; set; } = null!;
    public virtual DbSet<Material> Materials { get; set; } = null!;
    public virtual DbSet<Contract> Contracts { get; set; } = null!;
    public virtual DbSet<Worker> Workers { get; set; } = null!;
    public virtual DbSet<WorkerSalary> WorkerSalaries { get; set; } = null!;
    public virtual DbSet<Plan> Plans { get; set; } = null!;
    public virtual DbSet<BrigadeWorker> BrigadeWorker { get; set; } = null!;
    public virtual DbSet<BuildingObjectProvider> BuildingObjectProvider { get; set; } = null!;
    public virtual DbSet<ContractProvider> ContractProvider { get; set; } = null!;
    public virtual DbSet<ContractMaterial> ContractMaterial { get; set; } = null!;
    public virtual DbSet<MaterialProvider> MaterialProvider { get; set; } = null!;

    public BuildingWorksDbContext() { }
    public BuildingWorksDbContext(DbContextOptions<BuildingWorksDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureEntities();
    }
}