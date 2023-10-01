using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateBrigadesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrigadeId",
                table: "Workers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BrigadierBrigadeId",
                table: "Workers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Workers_BrigadierBrigadeId",
                table: "Workers",
                column: "BrigadierBrigadeId");

            migrationBuilder.CreateTable(
                name: "Brigade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BuildingObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    BrigadierId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brigade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brigade_BuildingObjects_BuildingObjectId",
                        column: x => x.BuildingObjectId,
                        principalTable: "BuildingObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Brigade_Workers_Id",
                        column: x => x.Id,
                        principalTable: "Workers",
                        principalColumn: "BrigadierBrigadeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_BrigadeId",
                table: "Workers",
                column: "BrigadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Brigade_BuildingObjectId",
                table: "Brigade",
                column: "BuildingObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Brigade_BrigadeId",
                table: "Workers",
                column: "BrigadeId",
                principalTable: "Brigade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Brigade_BrigadeId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Brigade");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Workers_BrigadierBrigadeId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_BrigadeId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "BrigadeId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "BrigadierBrigadeId",
                table: "Workers");
        }
    }
}
