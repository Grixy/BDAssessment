using Microsoft.EntityFrameworkCore.Migrations;

namespace BD_Assessment_WebAPI_Ruan_Gates.Migrations
{
    public partial class BatchAndNumberInputRemovingRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchAndNumberInput_Batches_BatchId",
                table: "BatchAndNumberInput");

            migrationBuilder.DropIndex(
                name: "IX_BatchAndNumberInput_BatchId",
                table: "BatchAndNumberInput");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "BatchAndNumberInput");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "BatchAndNumberInput",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BatchAndNumberInput_BatchId",
                table: "BatchAndNumberInput",
                column: "BatchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchAndNumberInput_Batches_BatchId",
                table: "BatchAndNumberInput",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
