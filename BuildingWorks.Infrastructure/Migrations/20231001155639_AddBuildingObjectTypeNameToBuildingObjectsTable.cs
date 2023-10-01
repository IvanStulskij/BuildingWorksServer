using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingWorks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildingObjectTypeNameToBuildingObjectsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ObjectType",
                table: "BuildingObjects",
                newName: "BuildingObjectTypeName");

            migrationBuilder.AddColumn<int>(
                name: "BuildingObjectType",
                table: "BuildingObjects",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingObjectType",
                table: "BuildingObjects");

            migrationBuilder.RenameColumn(
                name: "BuildingObjectTypeName",
                table: "BuildingObjects",
                newName: "ObjectType");
        }
    }
}
