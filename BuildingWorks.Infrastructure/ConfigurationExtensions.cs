using BuildingWorks.Infrastructure.Entities;
using BuildingWorks.Infrastructure.Entities.Joininig;
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
        ConfigureBuildingObjects(modelBuilder.Entity<BuildingObject>());
        ConfigureWorkerSalaries(modelBuilder.Entity<WorkerSalary>());
        ConfigureBrigadeWorker(modelBuilder.Entity<BrigadeWorker>());
        ConfigureBuildingObjectProvider(modelBuilder.Entity<BuildingObjectProvider>());
        ConfigureContractMaterial(modelBuilder.Entity<ContractMaterial>());
        ConfigureContractProvider(modelBuilder.Entity<ContractProvider>());
    }

    private static void ConfigureProviders(EntityTypeBuilder<Provider> providersBuilder)
    {
        providersBuilder
            .HasMany(provider => provider.Contracts)
            .WithMany(contract => contract.Providers);

        providersBuilder
            .HasMany(provider => provider.BuildingObjects)
            .WithMany(buildingObject => buildingObject.Providers)
            .UsingEntity<BuildingObjectProvider>();

        providersBuilder
            .HasMany(material => material.Contracts)
            .WithMany(contract => contract.Providers)
            .UsingEntity<ContractProvider>();
    }

    private static void ConfigureBuildingObjects(EntityTypeBuilder<BuildingObject> buildingObjectsBuilder)
    {
        buildingObjectsBuilder
            .HasMany(buildingObject => buildingObject.Providers)
            .WithMany(provider => provider.BuildingObjects)
            .UsingEntity<BuildingObjectProvider>();
    }

    private static void ConfigureMaterials(EntityTypeBuilder<Material> materialsBuilder)
    {
        materialsBuilder
            .HasMany(material => material.Contracts)
            .WithMany(contract => contract.Materials)
            .UsingEntity<ContractMaterial>();
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
            .WithMany(worker => worker.Brigades)
            .UsingEntity<BrigadeWorker>();
    }

    private static void ConfigureWorkers(EntityTypeBuilder<Worker> workersBuilder)
    {
        workersBuilder
            .HasMany(worker => worker.Brigades)
            .WithMany(brigade => brigade.Workers)
            .UsingEntity<BrigadeWorker>();

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

    private static void ConfigureBrigadeWorker(EntityTypeBuilder<BrigadeWorker> brigadeWorkerBuilder)
    {
        brigadeWorkerBuilder.HasKey(brigadeWorker => new
        {
            brigadeWorker.BrigadesId,
            brigadeWorker.WorkersId
        });
    }

    private static void ConfigureBuildingObjectProvider(EntityTypeBuilder<BuildingObjectProvider> buildingObjectProviderBuilder)
    {
        buildingObjectProviderBuilder.HasKey(buildingObjectProvider => new
        {
            buildingObjectProvider.BuildingObjectId,
            buildingObjectProvider.ProviderId
        });
    }

    public static void ConfigureContractMaterial(EntityTypeBuilder<ContractMaterial> contractMaterialBuilder)
    {
        contractMaterialBuilder.HasKey(contractMaterial => new
        {
            contractMaterial.ContractsId,
            contractMaterial.MaterialsId
        });
    }

    public static void ConfigureContractProvider(EntityTypeBuilder<ContractProvider> contractProviderBuilder)
    {
        contractProviderBuilder.HasKey(contractProvider => new
        {
            contractProvider.ContractsId,
            contractProvider.ProvidersId
        });
    }
}
