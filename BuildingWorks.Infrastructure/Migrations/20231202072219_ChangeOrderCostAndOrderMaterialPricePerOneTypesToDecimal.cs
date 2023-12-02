using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderCostAndOrderMaterialPricePerOneTypesToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Orders",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerOne",
                table: "OrderMaterial",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Cost",
                table: "Orders",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<float>(
                name: "PricePerOne",
                table: "OrderMaterial",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
