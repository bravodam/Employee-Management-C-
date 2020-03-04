using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class AddSaEmRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentId = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    PayDay = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salary_Employment_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employment",
                        principalColumn: "EmploymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salary_EmploymentId",
                table: "Salary",
                column: "EmploymentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salary");
        }
    }
}
