using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportClubs.Migrations
{
    public partial class changedtypeofphoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Teachers",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Students",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Clubs",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Announcements",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Teachers",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Students",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Clubs",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Announcements",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
