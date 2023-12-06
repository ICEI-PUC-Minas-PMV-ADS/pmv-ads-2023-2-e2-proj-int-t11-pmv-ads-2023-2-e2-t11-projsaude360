using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSaude360.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTabelaMedicamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Medicamentos_MedicamentoId",
                table: "Medicamentos");

            migrationBuilder.DropIndex(
                name: "IX_Medicamentos_MedicamentoId",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "MedicamentoId",
                table: "Medicamentos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicamentoId",
                table: "Medicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_MedicamentoId",
                table: "Medicamentos",
                column: "MedicamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Medicamentos_MedicamentoId",
                table: "Medicamentos",
                column: "MedicamentoId",
                principalTable: "Medicamentos",
                principalColumn: "Id");
        }
    }
}
