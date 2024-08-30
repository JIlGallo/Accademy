﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgettoContatti.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PersonaAddCittaDiNascita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CittaDiNascita",
                table: "Persona",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CittaDiNascita",
                table: "Persona");
        }
    }
}
