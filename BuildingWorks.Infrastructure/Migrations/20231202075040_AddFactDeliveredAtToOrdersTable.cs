using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFactDeliveredAtToOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveredAt",
                table: "Orders",
                newName: "FactDeliveredAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDeliverAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "PlannedDeliveredAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedDeliveredAt",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "FactDeliveredAt",
                table: "Orders",
                newName: "DeliveredAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDeliverAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
