using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DropContractTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contracts_ContractId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Contracts_ContractId",
                table: "Plans");

            migrationBuilder.DropTable(
                name: "ContractMaterial");

            migrationBuilder.DropTable(
                name: "ContractProvider");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Plans_ContractId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ContractId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Plans",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BuildingObjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    Conditions = table.Column<string>(type: "text", nullable: false),
                    SignedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_BuildingObjects_BuildingObjectId",
                        column: x => x.BuildingObjectId,
                        principalTable: "BuildingObjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContractMaterial",
                columns: table => new
                {
                    ContractsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uuid", nullable: false),
                    PricePerOne = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractMaterial", x => new { x.ContractsId, x.MaterialsId, x.ProviderId });
                    table.ForeignKey(
                        name: "FK_ContractMaterial_Contracts_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractMaterial_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractMaterial_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractProvider",
                columns: table => new
                {
                    ContractsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProvidersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractProvider", x => new { x.ContractsId, x.ProvidersId });
                    table.ForeignKey(
                        name: "FK_ContractProvider_Contracts_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractProvider_Providers_ProvidersId",
                        column: x => x.ProvidersId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_ContractId",
                table: "Plans",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContractId",
                table: "Orders",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractMaterial_MaterialsId",
                table: "ContractMaterial",
                column: "MaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractMaterial_ProviderId",
                table: "ContractMaterial",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProvider_ProvidersId",
                table: "ContractProvider",
                column: "ProvidersId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BuildingObjectId",
                table: "Contracts",
                column: "BuildingObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contracts_ContractId",
                table: "Orders",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Contracts_ContractId",
                table: "Plans",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
