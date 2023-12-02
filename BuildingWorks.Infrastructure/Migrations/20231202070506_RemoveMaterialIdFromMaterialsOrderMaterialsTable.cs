using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMaterialIdFromMaterialsOrderMaterialsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMaterial",
                table: "OrderMaterial");

            migrationBuilder.DropIndex(
                name: "IX_OrderMaterial_OrdersId",
                table: "OrderMaterial");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "OrderMaterial");

            migrationBuilder.AlterColumn<string>(
                name: "OrderID",
                table: "Orders",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMaterial",
                table: "OrderMaterial",
                columns: new[] { "OrdersId", "MaterialsId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderMaterial",
                table: "OrderMaterial");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                table: "Orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialId",
                table: "OrderMaterial",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderMaterial",
                table: "OrderMaterial",
                columns: new[] { "MaterialId", "OrdersId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderMaterial_OrdersId",
                table: "OrderMaterial",
                column: "OrdersId");
        }
    }
}
