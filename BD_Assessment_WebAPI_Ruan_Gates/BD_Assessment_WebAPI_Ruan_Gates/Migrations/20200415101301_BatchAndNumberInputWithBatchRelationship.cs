using Microsoft.EntityFrameworkCore.Migrations;

namespace BD_Assessment_WebAPI_Ruan_Gates.Migrations
{
    public partial class BatchAndNumberInputWithBatchRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumbersPerBatch",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "TotalBatches",
                table: "Batches");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "BatchAndNumberInput",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "NumbersPerBatch",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalBatches",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
