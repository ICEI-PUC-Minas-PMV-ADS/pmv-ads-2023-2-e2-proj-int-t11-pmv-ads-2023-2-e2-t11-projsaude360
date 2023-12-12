using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSaude360.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoTabelaTratamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Tratamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Tratamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Tratamentos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Tratamentos");
        }
    }
}
