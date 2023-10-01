using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateContractsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Signer",
                table: "Providers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SignedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Conditions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractMaterial",
                columns: table => new
                {
                    ContractsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractMaterial", x => new { x.ContractsId, x.MaterialsId });
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
                name: "IX_ContractMaterial_MaterialsId",
                table: "ContractMaterial",
                column: "MaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractProvider_ProvidersId",
                table: "ContractProvider",
                column: "ProvidersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractMaterial");

            migrationBuilder.DropTable(
                name: "ContractProvider");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropColumn(
                name: "Signer",
                table: "Providers");
        }
    }
}
