using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBrigadesToWorkerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Brigade_BrigadeId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_BrigadeId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "BrigadeId",
                table: "Workers");

            migrationBuilder.CreateTable(
                name: "BrigadeWorker",
                columns: table => new
                {
                    BrigadesId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrigadeWorker", x => new { x.BrigadesId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_BrigadeWorker_Brigade_BrigadesId",
                        column: x => x.BrigadesId,
                        principalTable: "Brigade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrigadeWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrigadeWorker_WorkersId",
                table: "BrigadeWorker",
                column: "WorkersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrigadeWorker");

            migrationBuilder.AddColumn<Guid>(
                name: "BrigadeId",
                table: "Workers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Workers_BrigadeId",
                table: "Workers",
                column: "BrigadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Brigade_BrigadeId",
                table: "Workers",
                column: "BrigadeId",
                principalTable: "Brigade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
