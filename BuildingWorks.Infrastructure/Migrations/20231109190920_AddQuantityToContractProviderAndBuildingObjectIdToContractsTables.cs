using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityToContractProviderAndBuildingObjectIdToContractsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuildingObjectId",
                table: "Contracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ContractMaterial",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BuildingObjectId",
                table: "Contracts",
                column: "BuildingObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_BuildingObjects_BuildingObjectId",
                table: "Contracts",
                column: "BuildingObjectId",
                principalTable: "BuildingObjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_BuildingObjects_BuildingObjectId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_BuildingObjectId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BuildingObjectId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ContractMaterial");
        }
    }
}
