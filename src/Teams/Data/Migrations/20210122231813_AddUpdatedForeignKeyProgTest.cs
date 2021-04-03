using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teams.Data.Migrations
{
    public partial class AddUpdatedForeignKeyProgTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramTests_Questions_QuestionId",
                table: "ProgramTests");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                table: "ProgramTests",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramTests_Questions_QuestionId",
                table: "ProgramTests",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramTests_Questions_QuestionId",
                table: "ProgramTests");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                table: "ProgramTests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramTests_Questions_QuestionId",
                table: "ProgramTests",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
