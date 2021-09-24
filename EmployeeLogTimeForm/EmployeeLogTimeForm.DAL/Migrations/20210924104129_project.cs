using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeLogTimeForm.DAL.Migrations
{
    public partial class project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientId);
                });

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
                name: "LogTimeForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false),
                    WorkItem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTimeForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogTimeForm_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogTimeForm_jobInfo_JobId",
                        column: x => x.JobId,
                        principalTable: "jobInfo",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogTimeForm_projectInfo_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "projectInfo",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogTimeForm_ClientId",
                table: "LogTimeForm",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LogTimeForm_JobId",
                table: "LogTimeForm",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_LogTimeForm_ProjectId",
                table: "LogTimeForm",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "LogTimeForm");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "jobInfo");

            migrationBuilder.DropTable(
                name: "projectInfo");
        }
    }
}
