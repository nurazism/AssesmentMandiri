using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssesmentMandiri.Migrations
{
    public partial class MigrationInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "player",
                schema: "dbo",
                columns: table => new
                {
                    player_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    place_of_birth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.player_id);
                });

            migrationBuilder.CreateTable(
                name: "team",
                schema: "dbo",
                columns: table => new
                {
                    team_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "career",
                schema: "dbo",
                columns: table => new
                {
                    career_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_id = table.Column<int>(type: "int", nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    join_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    appearances = table.Column<int>(type: "int", nullable: false),
                    goals = table.Column<int>(type: "int", nullable: false),
                    assists = table.Column<int>(type: "int", nullable: false),
                    cleansheets = table.Column<int>(type: "int", nullable: false),
                    yellow_cards = table.Column<int>(type: "int", nullable: false),
                    red_cards = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_career", x => x.career_id);
                    table.ForeignKey(
                        name: "FK_career_player_player_id",
                        column: x => x.player_id,
                        principalSchema: "dbo",
                        principalTable: "player",
                        principalColumn: "player_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_career_team_team_id",
                        column: x => x.team_id,
                        principalSchema: "dbo",
                        principalTable: "team",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "career",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "team",
                schema: "dbo");
        }
    }
}
