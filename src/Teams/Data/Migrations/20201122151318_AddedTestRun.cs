using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teams.Data.Migrations
{
    public partial class AddedTestRun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CorrectAnswersId",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "AverageScore",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnswersText = table.Column<string>(nullable: true)
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
                    Question = table.Column<Guid>(nullable: true),
                    Answers = table.Column<Guid>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    Attempts = table.Column<int>(nullable: false),
                    TestsCompleted = table.Column<string>(name: "Tests Completed", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRuns_Answers_Answers",
                        column: x => x.Answers,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRuns_Questions_Question",
                        column: x => x.Question,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestRuns_AspNetUsers_Tests Completed",
                        column: x => x.TestsCompleted,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CorrectAnswersId",
                table: "Questions",
                column: "CorrectAnswersId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_Answers",
                table: "TestRuns",
                column: "Answers");

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_Question",
                table: "TestRuns",
                column: "Question");

            migrationBuilder.CreateIndex(
                name: "IX_TestRuns_Tests Completed",
                table: "TestRuns",
                column: "Tests Completed");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_CorrectAnswersId",
                table: "Questions",
                column: "CorrectAnswersId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_CorrectAnswersId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "TestRuns");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CorrectAnswersId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectAnswersId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AverageScore",
                table: "AspNetUsers");
        }
    }
}
