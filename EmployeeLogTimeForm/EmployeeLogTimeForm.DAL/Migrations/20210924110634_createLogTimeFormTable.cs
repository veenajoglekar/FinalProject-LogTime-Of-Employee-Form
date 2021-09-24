using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeLogTimeForm.DAL.Migrations
{
    public partial class createLogTimeFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogTimeForm_clients_ClientId",
                table: "LogTimeForm");

            migrationBuilder.DropForeignKey(
                name: "FK_LogTimeForm_jobInfo_JobId",
                table: "LogTimeForm");

            migrationBuilder.DropForeignKey(
                name: "FK_LogTimeForm_projectInfo_ProjectId",
                table: "LogTimeForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LogTimeForm",
                table: "LogTimeForm");

            migrationBuilder.RenameTable(
                name: "LogTimeForm",
                newName: "logTimeForm");

            migrationBuilder.RenameIndex(
                name: "IX_LogTimeForm_ProjectId",
                table: "logTimeForm",
                newName: "IX_logTimeForm_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_LogTimeForm_JobId",
                table: "logTimeForm",
                newName: "IX_logTimeForm_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_LogTimeForm_ClientId",
                table: "logTimeForm",
                newName: "IX_logTimeForm_ClientId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "logTimeForm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "logTimeForm",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "logTimeForm",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minutes",
                table: "logTimeForm",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seconds",
                table: "logTimeForm",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_logTimeForm",
                table: "logTimeForm",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_logTimeForm_clients_ClientId",
                table: "logTimeForm",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_logTimeForm_jobInfo_JobId",
                table: "logTimeForm",
                column: "JobId",
                principalTable: "jobInfo",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_logTimeForm_projectInfo_ProjectId",
                table: "logTimeForm",
                column: "ProjectId",
                principalTable: "projectInfo",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logTimeForm_clients_ClientId",
                table: "logTimeForm");

            migrationBuilder.DropForeignKey(
                name: "FK_logTimeForm_jobInfo_JobId",
                table: "logTimeForm");

            migrationBuilder.DropForeignKey(
                name: "FK_logTimeForm_projectInfo_ProjectId",
                table: "logTimeForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_logTimeForm",
                table: "logTimeForm");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "logTimeForm");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "logTimeForm");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "logTimeForm");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "logTimeForm");

            migrationBuilder.DropColumn(
                name: "Seconds",
                table: "logTimeForm");

            migrationBuilder.RenameTable(
                name: "logTimeForm",
                newName: "LogTimeForm");

            migrationBuilder.RenameIndex(
                name: "IX_logTimeForm_ProjectId",
                table: "LogTimeForm",
                newName: "IX_LogTimeForm_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_logTimeForm_JobId",
                table: "LogTimeForm",
                newName: "IX_LogTimeForm_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_logTimeForm_ClientId",
                table: "LogTimeForm",
                newName: "IX_LogTimeForm_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LogTimeForm",
                table: "LogTimeForm",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogTimeForm_clients_ClientId",
                table: "LogTimeForm",
                column: "ClientId",
                principalTable: "clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogTimeForm_jobInfo_JobId",
                table: "LogTimeForm",
                column: "JobId",
                principalTable: "jobInfo",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogTimeForm_projectInfo_ProjectId",
                table: "LogTimeForm",
                column: "ProjectId",
                principalTable: "projectInfo",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
