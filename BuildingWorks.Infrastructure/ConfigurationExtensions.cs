using BuildingWorks.Infrastructure.Entities.Providers;
using BuildingWorks.Infrastructure.Entities.Workers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuildingWorks.Infrastructure;

public static class ConfigurationExtensions
{
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        ConfigureProviders(modelBuilder.Entity<Provider>());
        ConfigureMaterials(modelBuilder.Entity<Material>());
        ConfigureBrigades(modelBuilder.Entity<Brigade>());
        ConfigureWorkers(modelBuilder.Entity<Worker>());
        ConfigureWorkerSalaries(modelBuilder.Entity<WorkerSalary>());
    }

    private static void ConfigureProviders(EntityTypeBuilder<Provider> providersBuilder)
    {
        providersBuilder
            .HasMany(provider => provider.Contracts)
            .WithMany(contract => contract.Providers);
    }

    private static void ConfigureMaterials(EntityTypeBuilder<Material> materialsBuilder)
    {
        materialsBuilder
            .HasMany(material => material.Contracts)
            .WithMany(contract => contract.Materials);
    }

    private static void ConfigureBrigades(EntityTypeBuilder<Brigade> brigadesBuilder)
    {
        brigadesBuilder
            .HasOne(brigade => brigade.Brigadier)
            .WithOne(brigadier => brigadier.BrigadierBrigade)
            .HasPrincipalKey<Worker>(worker => worker.BrigadierBrigadeId)
            .HasForeignKey<Brigade>(brigade => brigade.Id);

        brigadesBuilder
            .HasMany(brigade => brigade.Workers)
            .WithOne(brigadier => brigadier.Brigade);
    }

    private static void ConfigureWorkers(EntityTypeBuilder<Worker> workersBuilder)
    {
        workersBuilder
            .HasOne(worker => worker.Brigade)
            .WithMany(brigade => brigade.Workers)
            .OnDelete(DeleteBehavior.Restrict);

        workersBuilder
            .HasOne(worker => worker.BrigadierBrigade)
            .WithOne(brigade => brigade.Brigadier)
            .HasPrincipalKey<Worker>(brigadier => brigadier.BrigadierBrigadeId)
            .HasForeignKey<Brigade>(brigade => brigade.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureWorkerSalaries(EntityTypeBuilder<WorkerSalary> workersSalariesBuilder)
    {
        workersSalariesBuilder
            .HasOne(workerSalary => workerSalary.Worker)
            .WithMany(worker => worker.WorkerSalaries)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
