using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miguel.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDaFolha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    folhaId = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    Quantidade = table.Column<double>(type: "REAL", nullable: false),
                    Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    salarioBruto = table.Column<double>(type: "REAL", nullable: false),
                    impostoIrrf = table.Column<double>(type: "REAL", nullable: false),
                    impostoInss = table.Column<double>(type: "REAL", nullable: false),
                    impostoFgts = table.Column<double>(type: "REAL", nullable: false),
                    salarioLiquido = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.folhaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");
        }
    }
}
