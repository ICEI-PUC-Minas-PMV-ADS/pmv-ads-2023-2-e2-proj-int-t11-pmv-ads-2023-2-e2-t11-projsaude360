using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSaude360.Migrations
{
    /// <inheritdoc />
    public partial class GerenciamentoBancoMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Cadastros_CadastrosId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Tratamentos_TratamentoId",
                table: "Medicamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tratamentos_Cadastros_CadastroId",
                table: "Tratamentos");

            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "Tratamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Obs",
                table: "Tratamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Dosagem",
                table: "Tratamentos",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "CadastroId",
                table: "Tratamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Administracao",
                table: "Tratamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TratamentoId",
                table: "Medicamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Obs",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Dosagem",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Recomendacoes",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomeMedico",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MotivoConsulta",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CadastrosId",
                table: "Consultas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Cadastros_CadastrosId",
                table: "Consultas",
                column: "CadastrosId",
                principalTable: "Cadastros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Tratamentos_TratamentoId",
                table: "Medicamentos",
                column: "TratamentoId",
                principalTable: "Tratamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tratamentos_Cadastros_CadastroId",
                table: "Tratamentos",
                column: "CadastroId",
                principalTable: "Cadastros",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Cadastros_CadastrosId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Tratamentos_TratamentoId",
                table: "Medicamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Tratamentos_Cadastros_CadastroId",
                table: "Tratamentos");

            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "Tratamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Obs",
                table: "Tratamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Dosagem",
                table: "Tratamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CadastroId",
                table: "Tratamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Administracao",
                table: "Tratamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TratamentoId",
                table: "Medicamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Obs",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Info",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dosagem",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Recomendacoes",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeMedico",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MotivoConsulta",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CadastrosId",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Cadastros_CadastrosId",
                table: "Consultas",
                column: "CadastrosId",
                principalTable: "Cadastros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Tratamentos_TratamentoId",
                table: "Medicamentos",
                column: "TratamentoId",
                principalTable: "Tratamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tratamentos_Cadastros_CadastroId",
                table: "Tratamentos",
                column: "CadastroId",
                principalTable: "Cadastros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
