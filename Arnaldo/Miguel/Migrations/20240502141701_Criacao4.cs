using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miguel.Migrations
{
    /// <inheritdoc />
    public partial class Criacao4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folhas_Funcionarios_funcionarioId",
                table: "Folhas");

            migrationBuilder.DropIndex(
                name: "IX_Folhas_funcionarioId",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "funcionarioId",
                table: "Folhas");

            migrationBuilder.AlterColumn<string>(
                name: "FuncId",
                table: "Folhas",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FuncId",
                table: "Folhas",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "funcionarioId",
                table: "Folhas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_funcionarioId",
                table: "Folhas",
                column: "funcionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folhas_Funcionarios_funcionarioId",
                table: "Folhas",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "funcionarioId");
        }
    }
}
