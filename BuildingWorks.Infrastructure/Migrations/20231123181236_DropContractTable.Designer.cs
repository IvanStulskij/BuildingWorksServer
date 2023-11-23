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
    [Migration("20231123181236_DropContractTable")]
    partial class DropContractTable
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

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.OrderMaterial", b =>
                {
                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrdersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MaterialsId")
                        .HasColumnType("uuid");

                    b.Property<float>("PricePerOne")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("MaterialId", "OrdersId");

                    b.HasIndex("MaterialsId");

                    b.HasIndex("OrdersId");

                    b.ToTable("OrderMaterial");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BuildingObjectId")
                        .HasColumnType("uuid");

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime?>("DeliveredAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uuid");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDeliverAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuildingObjectId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Orders");
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

                    b.ToTable("Plans");
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

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Joininig.OrderMaterial", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Material", "Material")
                        .WithMany("MaterialOrders")
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Order", "Order")
                        .WithMany("OrderMaterials")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Order", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.BuildingObject", "BuildingObject")
                        .WithMany("Orders")
                        .HasForeignKey("BuildingObjectId");

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Provider", "Provider")
                        .WithMany("Orders")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingObject");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Plans.Plan", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.BuildingObject", "BuildingObject")
                        .WithMany("Plans")
                        .HasForeignKey("BuildingObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("Orders");

                    b.Navigation("Plans");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Order", b =>
                {
                    b.Navigation("OrderMaterials");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Material", b =>
                {
                    b.Navigation("MaterialOrders");

                    b.Navigation("MaterialProviders");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Provider", b =>
                {
                    b.Navigation("MaterialProviders");

                    b.Navigation("Orders");
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
