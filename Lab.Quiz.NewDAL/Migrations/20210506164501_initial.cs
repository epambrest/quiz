using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab.Quiz.NewDAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizCardWithProgramCode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomingData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedOutgoingData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximumExecutionTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizCardWithProgramCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRight = table.Column<bool>(type: "bit", nullable: false),
                    QuizCardId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardAnswers_QuizCards_QuizCardId",
                        column: x => x.QuizCardId,
                        principalTable: "QuizCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuizCard",
                columns: table => new
                {
                    QuizCardsId = table.Column<long>(type: "bigint", nullable: false),
                    QuizzesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuizCard", x => new { x.QuizCardsId, x.QuizzesId });
                    table.ForeignKey(
                        name: "FK_QuizQuizCard_QuizCards_QuizCardsId",
                        column: x => x.QuizCardsId,
                        principalTable: "QuizCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuizCard_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuizCardWithProgramCode",
                columns: table => new
                {
                    QuizCardsWithProgramCodeId = table.Column<long>(type: "bigint", nullable: false),
                    QuizzesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuizCardWithProgramCode", x => new { x.QuizCardsWithProgramCodeId, x.QuizzesId });
                    table.ForeignKey(
                        name: "FK_QuizQuizCardWithProgramCode_QuizCardWithProgramCode_QuizCardsWithProgramCodeId",
                        column: x => x.QuizCardsWithProgramCodeId,
                        principalTable: "QuizCardWithProgramCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuizCardWithProgramCode_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardAnswers_QuizCardId",
                table: "CardAnswers",
                column: "QuizCardId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuizCard_QuizzesId",
                table: "QuizQuizCard",
                column: "QuizzesId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuizCardWithProgramCode_QuizzesId",
                table: "QuizQuizCardWithProgramCode",
                column: "QuizzesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardAnswers");

            migrationBuilder.DropTable(
                name: "QuizQuizCard");

            migrationBuilder.DropTable(
                name: "QuizQuizCardWithProgramCode");

            migrationBuilder.DropTable(
                name: "QuizCards");

            migrationBuilder.DropTable(
                name: "QuizCardWithProgramCode");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
