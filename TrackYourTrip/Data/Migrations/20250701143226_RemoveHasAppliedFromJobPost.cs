using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackYourTrip.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHasAppliedFromJobPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasApplied",
                table: "JobPosts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasApplied",
                table: "JobPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
