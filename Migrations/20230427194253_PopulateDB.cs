using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcGroup7.Migrations
{
    public partial class PopulateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EngineerId",
                table: "Note",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineerId",
                table: "Note");
        }
    }
}
