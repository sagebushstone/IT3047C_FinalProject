using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IT3047C_FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class TrailInitialItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "TrailId", "Description", "DifficultyLevel", "Park", "State", "TrailName" },
                values: new object[,]
                {
                    { 1, "The Colerain trail is an excellent beginner level trail in the beautiful Mt. Airy Forest, located on the west side of Cincinnati. As the trail is under a mile, expect an easy forest walk that can be completed in under an hour.", 1, "Mt. Airy Forest", "Ohio", "Colerain Trail" },
                    { 2, "The Ponderosa trail is an intermediate level 4 mile hiking trail in the scenic Mt. Airy Forest. This trail will take you on a meandering path through a majority of the eastern half of the forest, and runs in tandem with multiple other trails located within the forest. If you are looking for a solid challenge, this may be the trail for you.", 3, "Mt. Airy Forest", "Ohio", "Ponderosa Trail" },
                    { 3, "Buttercup Valley and Parker Woods are a smaller nature reserve located on the west side of Cincinnati. The 1.4 mile long B Loop Trail takes you through both of the reserves, and acts as a more casual nature trail. Even so, there are still plenty of scenic twists, turns, bridges, and hills to keep the trail interesting even for more experienced hikers.", 2, "Buttercup Valley and Parker Woods", "Ohio", "B Loop Trail" },
                    { 4, "In the gorgeous Miami Whitewater Forest located in Harrison OH, hikers are treated to multiple options for trails. The main trail is the Shaker Trace Loop, which gives hikers an option between the easier 1.4 mile inner loop, or the more challenging 7.8 mile outer loop. With either choice, you will be treated to the beautiful forest, challenging inclines, refreshing waterways all on a paved pathway. If you are looking for an excellent entry level intermediate level course that’s still easy on the knees, This trail may be for you.", 4, "Miami Whitewater Forest", "Ohio", "Shaker Trace Outer Loop" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "TrailId",
                keyValue: 4);
        }
    }
}
