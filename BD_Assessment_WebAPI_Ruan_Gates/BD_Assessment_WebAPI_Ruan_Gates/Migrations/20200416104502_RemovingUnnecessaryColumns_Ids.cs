using Microsoft.EntityFrameworkCore.Migrations;

namespace BD_Assessment_WebAPI_Ruan_Gates.Migrations
{
    public partial class RemovingUnnecessaryColumns_Ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "BatchNumbers");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "BatchElements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "BatchNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "BatchElements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
