using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrackYourTrip.Migrations
{
    /// <inheritdoc />
    public partial class AddTripTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalExpense = table.Column<double>(type: "float", nullable: false),
                    StartKm = table.Column<int>(type: "int", nullable: true),
                    EndKm = table.Column<int>(type: "int", nullable: true),
                    TotalKm = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Description", "EndDate", "EndKm", "From", "Name", "Notes", "StartDate", "StartKm", "Status", "To", "TotalExpense", "TotalKm", "Type" },
                values: new object[,]
                {
                    { 1, "A relaxing summer retreat in the hills of Ooty.", new DateOnly(2025, 5, 20), null, "Keelapalur", "Ooty Summer Escape", "Wonderful weather, visited the Botanical Gardens and tea estates.", new DateOnly(2025, 5, 15), null, "Completed", "Ooty", 25000.0, null, "Family" },
                    { 2, "Exploring the lakes and forests of Kodaikanal.", new DateOnly(2025, 6, 14), null, "Keelapalur", "Kodaikanal Adventure", "Looking forward to trekking and boating.", new DateOnly(2025, 6, 10), null, "Planned", "Kodaikanal", 18000.0, null, "Friends" },
                    { 3, "A cultural trip to explore the royal city of Mysore.", new DateOnly(2025, 4, 7), null, "Keelapalur", "Mysore Cultural Tour", "Visited Mysore Palace and Brindavan Gardens.", new DateOnly(2025, 4, 5), null, "Completed", "Mysore", 15000.0, null, "Family" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
