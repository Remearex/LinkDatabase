using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWebDBproj.Migrations
{
    /// <inheritdoc />
    public partial class msc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "msc",
                table: "Link",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "msc",
                table: "Link");
        }
    }
}
