using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class UpdateStudentBatchProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentBatches_Students_BatchId",
                table: "StudentBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBatches_Batches_StudentId",
                table: "StudentBatches");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBatches_Batches_BatchId",
                table: "StudentBatches",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBatches_Students_StudentId",
                table: "StudentBatches",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentBatches_Batches_BatchId",
                table: "StudentBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBatches_Students_StudentId",
                table: "StudentBatches");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBatches_Students_BatchId",
                table: "StudentBatches",
                column: "BatchId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBatches_Batches_StudentId",
                table: "StudentBatches",
                column: "StudentId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
