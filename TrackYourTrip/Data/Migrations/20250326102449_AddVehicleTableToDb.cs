using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackYourTrip.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MileagePerLitre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                column: "VehicleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "VehicleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                column: "VehicleId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_VehicleId",
                table: "Trips",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Vehicles_VehicleId",
                table: "Trips",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Vehicles_VehicleId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Trips_VehicleId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Trips");
        }
    }
}
