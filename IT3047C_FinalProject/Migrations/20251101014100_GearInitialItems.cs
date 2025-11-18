using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IT3047C_FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class GearInitialItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gears",
                columns: new[] { "GearId", "Cost", "GearName", "RecommendedQuantity", "Weight" },
                values: new object[,]
                {
                    { 1, 100.0, "Backpack", 1, 0.40000000000000002 },
                    { 2, 150.0, "Hiking Shoes", 1, 0.5 },
                    { 3, 100.0, "Trekking Poles", 2, 0.5 },
                    { 4, 50.0, "2l Water Bottle", 1, 0.29999999999999999 },
                    { 5, 30.0, "Hat", 1, 0.10000000000000001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "GearId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "GearId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "GearId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "GearId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gears",
                keyColumn: "GearId",
                keyValue: 5);
        }
    }
}
