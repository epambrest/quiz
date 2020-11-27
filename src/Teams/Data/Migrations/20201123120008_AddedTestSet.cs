using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teams.Data.Migrations
{
    public partial class AddedTestSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRuns_AspNetUsers_Tests Completed",
                table: "TestRuns");

            migrationBuilder.DropIndex(
                name: "IX_TestRuns_Tests Completed",
                table: "TestRuns");

            migrationBuilder.DropColumn(
                name: "Tests Completed",
                table: "TestRuns");

            migrationBuilder.DropColumn(
                name: "SuccessRate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TestsCompleted",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "TestRunId",
                table: "TestRuns",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AnsweredQuestionId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestSets",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TestRuns = table.Column<string>(nullable: true),
                    TestSets = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSets_AspNetUsers_TestSets",
                        column: x => x.TestSets,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_TestRunId",
                table: "TestRuns",
                column: "TestRunId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AnsweredQuestionId",
                table: "Questions",
                column: "AnsweredQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSets_TestSets",
                table: "TestSets",
                column: "TestSets");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_TestSets_AnsweredQuestionId",
                table: "Questions",
                column: "AnsweredQuestionId",
                principalTable: "TestSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRuns_TestSets_TestRunId",
                table: "TestRuns",
                column: "TestRunId",
                principalTable: "TestSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_TestSets_AnsweredQuestionId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRuns_TestSets_TestRunId",
                table: "TestRuns");

            migrationBuilder.DropTable(
                name: "TestSets");

            migrationBuilder.DropIndex(
                name: "IX_TestRuns_TestRunId",
                table: "TestRuns");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AnsweredQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TestRunId",
                table: "TestRuns");

            migrationBuilder.DropColumn(
                name: "AnsweredQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "TestSets",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Tests Completed",
                table: "TestRuns",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageScore",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TestsCompleted",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_Tests Completed",
                table: "TestRuns",
                column: "Tests Completed");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRuns_AspNetUsers_Tests Completed",
                table: "TestRuns",
                column: "Tests Completed",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
