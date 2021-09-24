using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeLogTimeForm.DAL.Migrations.EmployeeLogDb
{
    public partial class createProjectInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projectInfo",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    BillableStatus = table.Column<string>(nullable: true),
                    Costing = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectInfo", x => x.ProjectId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projectInfo");
        }
    }
}
