using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeLogTimeForm.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Salary = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "jobInfo",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobInfo", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "projectInfo",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    BillableStatus = table.Column<string>(nullable: true),
                    Costing = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectInfo", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "logTimeForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false),
                    WorkItem = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Hours = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logTimeForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_logTimeForm_jobInfo_JobId",
                        column: x => x.JobId,
                        principalTable: "jobInfo",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_logTimeForm_projectInfo_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projectInfo",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_logTimeForm_JobId",
                table: "logTimeForm",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_logTimeForm_ProjectId",
                table: "logTimeForm",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "logTimeForm");

            migrationBuilder.DropTable(
                name: "jobInfo");

            migrationBuilder.DropTable(
                name: "projectInfo");
        }
    }
}
