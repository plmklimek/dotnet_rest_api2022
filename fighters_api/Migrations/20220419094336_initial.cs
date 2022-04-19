using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace fighters_api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fighter",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    age = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighter", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fights",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    _date = table.Column<DateTime>(type: "datetime", nullable: false),
                    blue_fighterid = table.Column<int>(type: "int", nullable: true),
                    red_fighterid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fights", x => x.id);
                    table.ForeignKey(
                        name: "FK_Fights_Fighter_blue_fighterid",
                        column: x => x.blue_fighterid,
                        principalTable: "Fighter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fights_Fighter_red_fighterid",
                        column: x => x.red_fighterid,
                        principalTable: "Fighter",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fights_blue_fighterid",
                table: "Fights",
                column: "blue_fighterid");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_red_fighterid",
                table: "Fights",
                column: "red_fighterid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fights");

            migrationBuilder.DropTable(
                name: "Fighter");
        }
    }
}
