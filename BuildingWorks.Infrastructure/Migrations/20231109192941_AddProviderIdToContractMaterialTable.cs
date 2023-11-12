using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProviderIdToContractMaterialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractMaterial",
                table: "ContractMaterial");

            migrationBuilder.AddColumn<Guid>(
                name: "ProviderId",
                table: "ContractMaterial",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractMaterial",
                table: "ContractMaterial",
                columns: new[] { "ContractsId", "MaterialsId", "ProviderId" });

            migrationBuilder.CreateIndex(
                name: "IX_ContractMaterial_ProviderId",
                table: "ContractMaterial",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractMaterial_Providers_ProviderId",
                table: "ContractMaterial",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractMaterial_Providers_ProviderId",
                table: "ContractMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractMaterial",
                table: "ContractMaterial");

            migrationBuilder.DropIndex(
                name: "IX_ContractMaterial_ProviderId",
                table: "ContractMaterial");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "ContractMaterial");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractMaterial",
                table: "ContractMaterial",
                columns: new[] { "ContractsId", "MaterialsId" });
        }
    }
}
