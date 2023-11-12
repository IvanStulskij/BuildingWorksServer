﻿// <auto-generated />
using System;
using BuildingWorks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    [DbContext(typeof(BuildingWorksDbContext))]
    [Migration("20231109191122_CreateMaterialProviderTable")]
    partial class CreateMaterialProviderTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.BuildingObject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BuildingObjectType")
                        .HasColumnType("integer");

                    b.Property<string>("BuildingObjectTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExecutorCompany")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ObjectCustomer")
                        .HasColumnType("text");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BuildingObjects");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.BrigadeWorker", b =>
                {
                    b.Property<Guid>("BrigadesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkersId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndWorkDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartWorkDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BrigadesId", "WorkersId");

                    b.HasIndex("WorkersId");

                    b.ToTable("BrigadeWorker");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.BuildingObjectProvider", b =>
                {
                    b.Property<Guid>("BuildingObjectsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProvidersId")
                        .HasColumnType("uuid");

                    b.HasKey("BuildingObjectsId", "ProvidersId");

                    b.HasIndex("ProvidersId");

                    b.ToTable("BuildingObjectProvider");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.ContractMaterial", b =>
                {
                    b.Property<Guid>("ContractsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MaterialsId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ContractsId", "MaterialsId");

                    b.HasIndex("MaterialsId");

                    b.ToTable("ContractMaterial");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.ContractProvider", b =>
                {
                    b.Property<Guid>("ContractsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProvidersId")
                        .HasColumnType("uuid");

                    b.HasKey("ContractsId", "ProvidersId");

                    b.HasIndex("ProvidersId");

                    b.ToTable("ContractProvider");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.MaterialProvider", b =>
                {
                    b.Property<Guid>("MaterialsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProvidersId")
                        .HasColumnType("uuid");

                    b.HasKey("MaterialsId", "ProvidersId");

                    b.HasIndex("ProvidersId");

                    b.ToTable("MaterialProvider");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Plans.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BuildingObjectId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CompleteTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<string>("PathToImage")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BuildingObjectId");

                    b.HasIndex("ContractId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BuildingObjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Conditions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("SignedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BuildingObjectId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Material", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PricePerOne")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalData")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Signer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Brigade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BrigadierId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BuildingObjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuildingObjectId");

                    b.ToTable("Brigade");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BrigadierBrigadeId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Post")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartWorkDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Workers", (string)null);
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.WorkerSalary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("BaseSalary")
                        .HasColumnType("real");

                    b.Property<int>("ChildrenCount")
                        .HasColumnType("integer");

                    b.Property<float>("Experience")
                        .HasColumnType("real");

                    b.Property<float>("TotalAmount")
                        .HasColumnType("real");

                    b.Property<int>("WorkedDays")
                        .HasColumnType("integer");

                    b.Property<Guid>("WorkerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerSalaries");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.BrigadeWorker", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.Workers.Brigade", "Brigade")
                        .WithMany("BrigadeWorkers")
                        .HasForeignKey("BrigadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Workers.Worker", "Worker")
                        .WithMany("BrigadeWorkers")
                        .HasForeignKey("WorkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brigade");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.BuildingObjectProvider", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.BuildingObject", "BuildingObject")
                        .WithMany()
                        .HasForeignKey("BuildingObjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProvidersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingObject");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.ContractMaterial", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.ContractProvider", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProvidersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.MaterialProvider", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Material", "Material")
                        .WithMany("MaterialProviders")
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Provider", "Provider")
                        .WithMany("MaterialProviders")
                        .HasForeignKey("ProvidersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Plans.Plan", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.BuildingObject", "BuildingObject")
                        .WithMany("Plans")
                        .HasForeignKey("BuildingObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Contract", "Contract")
                        .WithMany("Plans")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingObject");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Contract", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.BuildingObject", "BuildingObject")
                        .WithMany("Contracts")
                        .HasForeignKey("BuildingObjectId");

                    b.Navigation("BuildingObject");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Brigade", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.BuildingObject", "BuildingObject")
                        .WithMany("Brigades")
                        .HasForeignKey("BuildingObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Workers.Worker", "Brigadier")
                        .WithOne("BrigadierBrigade")
                        .HasForeignKey("BuildingWorks.Infrastructure.Entities.Workers.Brigade", "Id")
                        .HasPrincipalKey("BuildingWorks.Infrastructure.Entities.Workers.Worker", "BrigadierBrigadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brigadier");

                    b.Navigation("BuildingObject");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.WorkerSalary", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.Workers.Worker", "Worker")
                        .WithMany("WorkerSalaries")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.BuildingObject", b =>
                {
                    b.Navigation("Brigades");

                    b.Navigation("Contracts");

                    b.Navigation("Plans");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Contract", b =>
                {
                    b.Navigation("Plans");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Material", b =>
                {
                    b.Navigation("MaterialProviders");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Provider", b =>
                {
                    b.Navigation("MaterialProviders");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Brigade", b =>
                {
                    b.Navigation("BrigadeWorkers");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Worker", b =>
                {
                    b.Navigation("BrigadeWorkers");

                    b.Navigation("BrigadierBrigade");

                    b.Navigation("WorkerSalaries");
                });
#pragma warning restore 612, 618
        }
    }
}