using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcGroup7.Migrations
{
    public partial class RecordedDataID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordedData",
                table: "RecordedData");

            migrationBuilder.AddColumn<int>(
                name: "RecordedDataID",
                table: "RecordedData",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordedData",
                table: "RecordedData",
                column: "RecordedDataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordedData",
                table: "RecordedData");

            migrationBuilder.DropColumn(
                name: "RecordedDataID",
                table: "RecordedData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordedData",
                table: "RecordedData",
                column: "RecordedDataDate");
        }
    }
}
