using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebDBproj.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "asdf",
                table: "Link");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "asdf",
                table: "Link",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
