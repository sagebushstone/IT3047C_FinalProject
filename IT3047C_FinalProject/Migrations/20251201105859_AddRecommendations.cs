using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IT3047C_FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class AddRecommendations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    RecommendationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.RecommendationId);
                    table.ForeignKey(
                        name: "FK_Recommendations_Trails_TrailId",
                        column: x => x.TrailId,
                        principalTable: "Trails",
                        principalColumn: "TrailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendationItems",
                columns: table => new
                {
                    RecommendationItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecommendationId = table.Column<int>(type: "int", nullable: false),
                    GearId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendationItems", x => x.RecommendationItemId);
                    table.ForeignKey(
                        name: "FK_RecommendationItems_Gears_GearId",
                        column: x => x.GearId,
                        principalTable: "Gears",
                        principalColumn: "GearId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecommendationItems_Recommendations_RecommendationId",
                        column: x => x.RecommendationId,
                        principalTable: "Recommendations",
                        principalColumn: "RecommendationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Recommendations",
                columns: new[] { "RecommendationId", "TrailId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "RecommendationItems",
                columns: new[] { "RecommendationItemId", "GearId", "Quantity", "RecommendationId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 4, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationItems_GearId",
                table: "RecommendationItems",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendationItems_RecommendationId",
                table: "RecommendationItems",
                column: "RecommendationId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_TrailId",
                table: "Recommendations",
                column: "TrailId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecommendationItems");

            migrationBuilder.DropTable(
                name: "Recommendations");
        }
    }
}
