using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssesmentMandiri.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "dbo",
                table: "team",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "dbo",
                table: "team",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "dbo",
                table: "player",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "dbo",
                table: "player",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "dbo",
                table: "career",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "dbo",
                table: "career",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "dbo",
                table: "team");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "dbo",
                table: "team");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "dbo",
                table: "player");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "dbo",
                table: "player");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "dbo",
                table: "career");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "dbo",
                table: "career");
        }
    }
}
