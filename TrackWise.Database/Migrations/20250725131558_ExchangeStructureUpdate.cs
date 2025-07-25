using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackWise.Database.Migrations
{
    /// <inheritdoc />
    public partial class ExchangeStructureUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "IdentifierType",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "IdentifierValue",
                table: "Assets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Exchanges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Exchanges",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentifierType",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentifierValue",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
