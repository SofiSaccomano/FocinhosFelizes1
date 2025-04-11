using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FocinhosFelizes1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Doadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doadores",
                columns: table => new
                {
                    DoadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDoador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doadores", x => x.DoadorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doadores");
        }
    }
}
