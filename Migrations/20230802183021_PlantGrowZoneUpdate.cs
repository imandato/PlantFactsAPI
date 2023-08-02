using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantApi.Migrations
{
    /// <inheritdoc />
    public partial class PlantGrowZoneUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantGrowZones",
                table: "PlantGrowZones");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PlantGrowZones",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantGrowZones",
                table: "PlantGrowZones",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlantGrowZones_PlantFactId",
                table: "PlantGrowZones",
                column: "PlantFactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantGrowZones",
                table: "PlantGrowZones");

            migrationBuilder.DropIndex(
                name: "IX_PlantGrowZones_PlantFactId",
                table: "PlantGrowZones");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlantGrowZones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantGrowZones",
                table: "PlantGrowZones",
                columns: new[] { "PlantFactId", "GrowZoneId" });
        }
    }
}
