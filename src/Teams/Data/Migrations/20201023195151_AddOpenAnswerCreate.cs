using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teams.Data.Migrations
{
    public partial class AddOpenAnswerCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AnswerId",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OpenAnswerQuestionOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnswerText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenAnswerQuestionOption", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AnswerId",
                table: "Questions",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_OpenAnswerQuestionOption_AnswerId",
                table: "Questions",
                column: "AnswerId",
                principalTable: "OpenAnswerQuestionOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_OpenAnswerQuestionOption_AnswerId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "OpenAnswerQuestionOption");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AnswerId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Questions");
        }
    }
}
