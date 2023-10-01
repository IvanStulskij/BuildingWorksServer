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
    [Migration("20230930165956_CreateBrigadesTable")]
    partial class CreateBrigadesTable
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

                    b.Property<string>("ExecutorCompany")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ObjectCustomer")
                        .HasColumnType("text");

                    b.Property<string>("ObjectName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ObjectType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BuildingObjects");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Providers.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Conditions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SignedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

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
                        .IsRequired()
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

                    b.Property<Guid>("BrigadierId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BuildingObjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BuildingObjectId");

                    b.ToTable("Brigade");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BrigadeId")
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

                    b.HasIndex("BrigadeId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("ContractMaterial", b =>
                {
                    b.Property<Guid>("ContractsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MaterialsId")
                        .HasColumnType("uuid");

                    b.HasKey("ContractsId", "MaterialsId");

                    b.HasIndex("MaterialsId");

                    b.ToTable("ContractMaterial");
                });

            modelBuilder.Entity("ContractProvider", b =>
                {
                    b.Property<Guid>("ContractsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProvidersId")
                        .HasColumnType("uuid");

                    b.HasKey("ContractsId", "ProvidersId");

                    b.HasIndex("ProvidersId");

                    b.ToTable("ContractProvider");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Brigade", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.BuildingObject", "BuildingObject")
                        .WithMany()
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

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Worker", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.Workers.Brigade", "Brigade")
                        .WithMany("Workers")
                        .HasForeignKey("BrigadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brigade");
                });

            modelBuilder.Entity("ContractMaterial", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Contract", null)
                        .WithMany()
                        .HasForeignKey("ContractsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContractProvider", b =>
                {
                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Contract", null)
                        .WithMany()
                        .HasForeignKey("ContractsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingWorks.Infrastructure.Entities.Providers.Provider", null)
                        .WithMany()
                        .HasForeignKey("ProvidersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Brigade", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("BuildingWorks.Infrastructure.Entities.Workers.Worker", b =>
                {
                    b.Navigation("BrigadierBrigade");
                });
#pragma warning restore 612, 618
        }
    }
}
