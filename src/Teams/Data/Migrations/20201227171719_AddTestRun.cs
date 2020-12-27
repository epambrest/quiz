using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teams.Data.Migrations
{
    public partial class AddTestRun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnswerOptions = table.Column<string>(nullable: true),
                    AnswerText = table.Column<string>(nullable: true),
                    TestQuestionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestRuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TestedUserId = table.Column<string>(nullable: true),
                    TestId = table.Column<Guid>(nullable: false),
                    AnswersIds = table.Column<string>(nullable: true),
                    InProgress = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRuns", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "MultipleAnswerQuestionOption");

            migrationBuilder.DropTable(
                name: "TestRuns");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Questions");
        }
    }
}
