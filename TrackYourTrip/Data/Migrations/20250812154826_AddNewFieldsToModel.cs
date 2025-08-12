using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackYourTrip.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "JobPosts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Iteration",
                table: "JobPosts",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "Iteration",
                table: "JobPosts");
        }
    }
}
