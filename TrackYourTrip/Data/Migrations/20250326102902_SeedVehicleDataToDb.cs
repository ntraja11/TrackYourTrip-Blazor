using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrackYourTrip.Migrations
{
    /// <inheritdoc />
    public partial class SeedVehicleDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Fuel", "MileagePerLitre", "Name", "Owner" },
                values: new object[,]
                {
                    { 1, "Diesel", "10", "Mahindra Scorpio", "Raja" },
                    { 2, "CNG", "20", "Honda Accord", "Raja Anand" },
                    { 3, "Diesel", "10", "Mahindra Scorpio", "Balu" },
                    { 4, "Petrol", "16", "Maruti Swift", "Karthik Raja" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
