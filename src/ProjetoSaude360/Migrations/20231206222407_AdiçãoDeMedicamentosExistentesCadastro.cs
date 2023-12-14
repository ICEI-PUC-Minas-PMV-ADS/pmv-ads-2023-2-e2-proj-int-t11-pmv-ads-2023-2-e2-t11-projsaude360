using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSaude360.Migrations
{
    /// <inheritdoc />
    public partial class AdiçãoDeMedicamentosExistentesCadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CadastrosId",
                table: "Medicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicamentoId",
                table: "Medicamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_CadastrosId",
                table: "Medicamentos",
                column: "CadastrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_MedicamentoId",
                table: "Medicamentos",
                column: "MedicamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Cadastros_CadastrosId",
                table: "Medicamentos",
                column: "CadastrosId",
                principalTable: "Cadastros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Medicamentos_MedicamentoId",
                table: "Medicamentos",
                column: "MedicamentoId",
                principalTable: "Medicamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Cadastros_CadastrosId",
                table: "Medicamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Medicamentos_MedicamentoId",
                table: "Medicamentos");

            migrationBuilder.DropIndex(
                name: "IX_Medicamentos_CadastrosId",
                table: "Medicamentos");

            migrationBuilder.DropIndex(
                name: "IX_Medicamentos_MedicamentoId",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "CadastrosId",
                table: "Medicamentos");

            migrationBuilder.DropColumn(
                name: "MedicamentoId",
                table: "Medicamentos");
        }
    }
}
