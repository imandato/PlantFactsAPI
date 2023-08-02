using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantApi.Migrations
{
    /// <inheritdoc />
    public partial class PlantGrowZone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantGrowZones_PlantGrowZones_PlantGrowZoneId_PlantGrowZoneGrowZoneId",
                table: "PlantGrowZones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantGrowZones",
                table: "PlantGrowZones");

            migrationBuilder.DropIndex(
                name: "IX_PlantGrowZones_PlantFactId",
                table: "PlantGrowZones");

            migrationBuilder.DropIndex(
                name: "IX_PlantGrowZones_PlantGrowZoneId_PlantGrowZoneGrowZoneId",
                table: "PlantGrowZones");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlantGrowZones");

            migrationBuilder.DropColumn(
                name: "PlantGrowZoneGrowZoneId",
                table: "PlantGrowZones");

            migrationBuilder.DropColumn(
                name: "PlantGrowZoneId",
                table: "PlantGrowZones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantGrowZones",
                table: "PlantGrowZones",
                columns: new[] { "PlantFactId", "GrowZoneId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantGrowZones",
                table: "PlantGrowZones");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PlantGrowZones",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PlantGrowZoneGrowZoneId",
                table: "PlantGrowZones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PlantGrowZoneId",
                table: "PlantGrowZones",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantGrowZones",
                table: "PlantGrowZones",
                columns: new[] { "Id", "GrowZoneId" });

            migrationBuilder.CreateIndex(
                name: "IX_PlantGrowZones_PlantFactId",
                table: "PlantGrowZones",
                column: "PlantFactId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantGrowZones_PlantGrowZoneId_PlantGrowZoneGrowZoneId",
                table: "PlantGrowZones",
                columns: new[] { "PlantGrowZoneId", "PlantGrowZoneGrowZoneId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlantGrowZones_PlantGrowZones_PlantGrowZoneId_PlantGrowZoneGrowZoneId",
                table: "PlantGrowZones",
                columns: new[] { "PlantGrowZoneId", "PlantGrowZoneGrowZoneId" },
                principalTable: "PlantGrowZones",
                principalColumns: new[] { "Id", "GrowZoneId" });
        }
    }
}
