using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab.Quiz.NewDAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRight = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardAnswers", x => x.Id);
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
                name: "QuizCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizCards_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardAnswerQuizCard",
                columns: table => new
                {
                    CardAnswersId = table.Column<long>(type: "bigint", nullable: false),
                    QuizCardsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardAnswerQuizCard", x => new { x.CardAnswersId, x.QuizCardsId });
                    table.ForeignKey(
                        name: "FK_CardAnswerQuizCard_CardAnswers_CardAnswersId",
                        column: x => x.CardAnswersId,
                        principalTable: "CardAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardAnswerQuizCard_QuizCards_QuizCardsId",
                        column: x => x.QuizCardsId,
                        principalTable: "QuizCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardAnswerQuizCard_QuizCardsId",
                table: "CardAnswerQuizCard",
                column: "QuizCardsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizCards_QuizId",
                table: "QuizCards",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardAnswerQuizCard");

            migrationBuilder.DropTable(
                name: "CardAnswers");

            migrationBuilder.DropTable(
                name: "QuizCards");

            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
