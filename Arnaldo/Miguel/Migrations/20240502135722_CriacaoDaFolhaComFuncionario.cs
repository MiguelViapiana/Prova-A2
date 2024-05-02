using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miguel.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDaFolhaComFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FuncId",
                table: "Folhas",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuncId",
                table: "Folhas");
        }
    }
}
