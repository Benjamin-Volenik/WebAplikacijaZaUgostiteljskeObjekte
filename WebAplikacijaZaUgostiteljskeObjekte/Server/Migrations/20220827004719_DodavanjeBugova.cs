using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplikacijaZaUgostiteljskeObjekte.Server.Migrations
{
    public partial class DodavanjeBugova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiGrad",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UgostiteljskiObjektiKucniBroj",
                table: "UgostiteljskiObjekti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UgostiteljskiObjektiLatituda",
                table: "UgostiteljskiObjekti",
                type: "decimal(8,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UgostiteljskiObjektiLongituda",
                table: "UgostiteljskiObjekti",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiTip",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UgostiteljskiObjektiUlica",
                table: "UgostiteljskiObjekti",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OcjenaVrijeme",
                table: "Ocjene",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentTime",
                table: "Komentari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Pica",
                columns: table => new
                {
                    DrinksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UgostiteljskiObjektiId = table.Column<int>(type: "int", nullable: false),
                    NazivPica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cjena = table.Column<decimal>(type: "money", nullable: false),
                    PiceNormativ = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pica", x => x.DrinksId);
                });

            migrationBuilder.CreateTable(
                name: "PrijavljeniBugovi",
                columns: table => new
                {
                    BugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BugText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavljeniBugovi", x => x.BugId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pica");

            migrationBuilder.DropTable(
                name: "PrijavljeniBugovi");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiGrad",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiKucniBroj",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiLatituda",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiLongituda",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiTip",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "UgostiteljskiObjektiUlica",
                table: "UgostiteljskiObjekti");

            migrationBuilder.DropColumn(
                name: "OcjenaVrijeme",
                table: "Ocjene");

            migrationBuilder.DropColumn(
                name: "CommentTime",
                table: "Komentari");
        }
    }
}
