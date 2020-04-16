using Microsoft.EntityFrameworkCore.Migrations;

namespace BD_Assessment_WebAPI_Ruan_Gates.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatchElementBatchId",
                table: "BatchNumbers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BatchRequestId",
                table: "BatchElements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BatchNumbers_BatchElementBatchId",
                table: "BatchNumbers",
                column: "BatchElementBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchElements_BatchRequestId",
                table: "BatchElements",
                column: "BatchRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchElements_Batches_BatchRequestId",
                table: "BatchElements",
                column: "BatchRequestId",
                principalTable: "Batches",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchNumbers_BatchElements_BatchElementBatchId",
                table: "BatchNumbers",
                column: "BatchElementBatchId",
                principalTable: "BatchElements",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchElements_Batches_BatchRequestId",
                table: "BatchElements");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchNumbers_BatchElements_BatchElementBatchId",
                table: "BatchNumbers");

            migrationBuilder.DropIndex(
                name: "IX_BatchNumbers_BatchElementBatchId",
                table: "BatchNumbers");

            migrationBuilder.DropIndex(
                name: "IX_BatchElements_BatchRequestId",
                table: "BatchElements");

            migrationBuilder.DropColumn(
                name: "BatchElementBatchId",
                table: "BatchNumbers");

            migrationBuilder.DropColumn(
                name: "BatchRequestId",
                table: "BatchElements");
        }
    }
}
