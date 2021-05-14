using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab.Quiz.NewDAL.Migrations
{
    public partial class addtableqcwpc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuizCardWithProgramCode_QuizCardWithProgramCode_QuizCardsWithProgramCodeId",
                table: "QuizQuizCardWithProgramCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizCardWithProgramCode",
                table: "QuizCardWithProgramCode");

            migrationBuilder.RenameTable(
                name: "QuizCardWithProgramCode",
                newName: "QuizCardsWithProgramCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizCardsWithProgramCode",
                table: "QuizCardsWithProgramCode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuizCardWithProgramCode_QuizCardsWithProgramCode_QuizCardsWithProgramCodeId",
                table: "QuizQuizCardWithProgramCode",
                column: "QuizCardsWithProgramCodeId",
                principalTable: "QuizCardsWithProgramCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuizCardWithProgramCode_QuizCardsWithProgramCode_QuizCardsWithProgramCodeId",
                table: "QuizQuizCardWithProgramCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizCardsWithProgramCode",
                table: "QuizCardsWithProgramCode");

            migrationBuilder.RenameTable(
                name: "QuizCardsWithProgramCode",
                newName: "QuizCardWithProgramCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizCardWithProgramCode",
                table: "QuizCardWithProgramCode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuizCardWithProgramCode_QuizCardWithProgramCode_QuizCardsWithProgramCodeId",
                table: "QuizQuizCardWithProgramCode",
                column: "QuizCardsWithProgramCodeId",
                principalTable: "QuizCardWithProgramCode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
