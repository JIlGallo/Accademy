using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgettoContatti.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Pk_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Eta = table.Column<int>(type: "int", nullable: false),
                    DataDiNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genere = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Pk_Id);
                });

            migrationBuilder.CreateTable(
                name: "Contatto",
                columns: table => new
                {
                    Pk_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_Persona_Id = table.Column<int>(type: "int", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatto", x => x.Pk_Id);
                    table.ForeignKey(
                        name: "FK_Contatto_Persona_Fk_Persona_Id",
                        column: x => x.Fk_Persona_Id,
                        principalTable: "Persona",
                        principalColumn: "Pk_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatto_Fk_Persona_Id",
                table: "Contatto",
                column: "Fk_Persona_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatto");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
