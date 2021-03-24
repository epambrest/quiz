using Microsoft.EntityFrameworkCore.Migrations;
using Lab.Quiz.DAL;

namespace Lab.Quiz.DAL.Migrations
{
    public partial class UdpdateQueuedProgramsForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QueuedPrograms_questionId",
                table: "QueuedPrograms",
                column: "questionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QueuedPrograms_Questions_questionId",
                table: "QueuedPrograms",
                column: "questionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QueuedPrograms_Questions_questionId",
                table: "QueuedPrograms");

            migrationBuilder.DropIndex(
                name: "IX_QueuedPrograms_questionId",
                table: "QueuedPrograms");
        }
    }
}
