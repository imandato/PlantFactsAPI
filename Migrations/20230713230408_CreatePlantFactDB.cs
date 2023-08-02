using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantApi.Migrations
{
    /// <inheritdoc />
    public partial class CreatePlantFactDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrowZones",
                columns: table => new
                {
                    GrowZoneId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrowZoneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrowZoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    GrowZoneDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowZones", x => x.GrowZoneId);
                });

            migrationBuilder.CreateTable(
                name: "PlantFacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScientificName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Light = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Water = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantFacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantGrowZones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    GrowZoneId = table.Column<long>(type: "bigint", nullable: false),
                    PlantFactId = table.Column<long>(type: "bigint", nullable: false),
                    PlantGrowZoneGrowZoneId = table.Column<long>(type: "bigint", nullable: true),
                    PlantGrowZoneId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantGrowZones", x => new { x.Id, x.GrowZoneId });
                    table.ForeignKey(
                        name: "FK_PlantGrowZones_GrowZones_GrowZoneId",
                        column: x => x.GrowZoneId,
                        principalTable: "GrowZones",
                        principalColumn: "GrowZoneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantGrowZones_PlantFacts_PlantFactId",
                        column: x => x.PlantFactId,
                        principalTable: "PlantFacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantGrowZones_PlantGrowZones_PlantGrowZoneId_PlantGrowZoneGrowZoneId",
                        columns: x => new { x.PlantGrowZoneId, x.PlantGrowZoneGrowZoneId },
                        principalTable: "PlantGrowZones",
                        principalColumns: new[] { "Id", "GrowZoneId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantGrowZones_GrowZoneId",
                table: "PlantGrowZones",
                column: "GrowZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantGrowZones_PlantFactId",
                table: "PlantGrowZones",
                column: "PlantFactId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantGrowZones_PlantGrowZoneId_PlantGrowZoneGrowZoneId",
                table: "PlantGrowZones",
                columns: new[] { "PlantGrowZoneId", "PlantGrowZoneGrowZoneId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantGrowZones");

            migrationBuilder.DropTable(
                name: "GrowZones");

            migrationBuilder.DropTable(
                name: "PlantFacts");
        }
    }
}
