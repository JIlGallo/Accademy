using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgettoContatti.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RimozioneCittaDiNascita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CittaDiNascita",
                table: "Persona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CittaDiNascita",
                table: "Persona",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
