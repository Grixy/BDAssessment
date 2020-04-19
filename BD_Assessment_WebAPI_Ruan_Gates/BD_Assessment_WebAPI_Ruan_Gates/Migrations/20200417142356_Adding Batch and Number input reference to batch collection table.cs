using Microsoft.EntityFrameworkCore.Migrations;

namespace BD_Assessment_WebAPI_Ruan_Gates.Migrations
{
    public partial class AddingBatchandNumberinputreferencetobatchcollectiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatchAndNumberInputRequestId",
                table: "Batches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Batches_BatchAndNumberInputRequestId",
                table: "Batches",
                column: "BatchAndNumberInputRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_BatchAndNumberInput_BatchAndNumberInputRequestId",
                table: "Batches",
                column: "BatchAndNumberInputRequestId",
                principalTable: "BatchAndNumberInput",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_BatchAndNumberInput_BatchAndNumberInputRequestId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_BatchAndNumberInputRequestId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "BatchAndNumberInputRequestId",
                table: "Batches");
        }
    }
}
