using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssesmentMandiri.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_career_player_player_id",
                schema: "dbo",
                table: "career");

            migrationBuilder.DropForeignKey(
                name: "FK_career_team_team_id",
                schema: "dbo",
                table: "career");

            migrationBuilder.DropIndex(
                name: "IX_career_player_id",
                schema: "dbo",
                table: "career");

            migrationBuilder.DropIndex(
                name: "IX_career_team_id",
                schema: "dbo",
                table: "career");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "dbo",
                table: "career",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                schema: "dbo",
                table: "career",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_career_player_id",
                schema: "dbo",
                table: "career",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_career_team_id",
                schema: "dbo",
                table: "career",
                column: "team_id");

            migrationBuilder.AddForeignKey(
                name: "FK_career_player_player_id",
                schema: "dbo",
                table: "career",
                column: "player_id",
                principalSchema: "dbo",
                principalTable: "player",
                principalColumn: "player_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_career_team_team_id",
                schema: "dbo",
                table: "career",
                column: "team_id",
                principalSchema: "dbo",
                principalTable: "team",
                principalColumn: "team_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
