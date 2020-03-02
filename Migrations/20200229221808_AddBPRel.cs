using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class AddBPRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgrammeId",
                table: "Batches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Batches_ProgrammeId",
                table: "Batches",
                column: "ProgrammeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Programmes_ProgrammeId",
                table: "Batches",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "ProgrammeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Programmes_ProgrammeId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_ProgrammeId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "ProgrammeId",
                table: "Batches");
        }
    }
}
