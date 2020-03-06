using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class MakeStudentCompanyRelMTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employments_StudentId",
                table: "Employments");

            migrationBuilder.CreateTable(
                name: "StudentCompanies",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCompanies", x => new { x.StudentId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_StudentCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCompanies_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employments_StudentId",
                table: "Employments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCompanies_CompanyId",
                table: "StudentCompanies",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCompanies");

            migrationBuilder.DropIndex(
                name: "IX_Employments_StudentId",
                table: "Employments");

            migrationBuilder.CreateIndex(
                name: "IX_Employments_StudentId",
                table: "Employments",
                column: "StudentId",
                unique: true);
        }
    }
}
