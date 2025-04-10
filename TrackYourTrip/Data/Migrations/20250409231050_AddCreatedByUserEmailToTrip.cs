using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackYourTrip.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByUserEmailToTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserEmail",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedByUserEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedByUserEmail",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedByUserEmail",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserEmail",
                table: "Trips");
        }
    }
}
