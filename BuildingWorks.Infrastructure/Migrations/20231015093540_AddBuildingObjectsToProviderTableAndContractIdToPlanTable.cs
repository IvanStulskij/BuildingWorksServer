using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildingObjectsToProviderTableAndContractIdToPlanTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "Plans",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BuildingObjectProvider",
                columns: table => new
                {
                    BuildingObjectsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProvidersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingObjectProvider", x => new { x.BuildingObjectsId, x.ProvidersId });
                    table.ForeignKey(
                        name: "FK_BuildingObjectProvider_BuildingObjects_BuildingObjectsId",
                        column: x => x.BuildingObjectsId,
                        principalTable: "BuildingObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingObjectProvider_Providers_ProvidersId",
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
                name: "IX_BuildingObjectProvider_ProvidersId",
                table: "BuildingObjectProvider",
                column: "ProvidersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Contracts_ContractId",
                table: "Plans",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Contracts_ContractId",
                table: "Plans");

            migrationBuilder.DropTable(
                name: "BuildingObjectProvider");

            migrationBuilder.DropIndex(
                name: "IX_Plans_ContractId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Plans");
        }
    }
}
