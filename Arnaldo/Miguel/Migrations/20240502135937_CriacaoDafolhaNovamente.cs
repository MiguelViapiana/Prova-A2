using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miguel.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDafolhaNovamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Folhas_FuncId",
                table: "Folhas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Folhas_FuncId",
                table: "Folhas",
                column: "FuncId");
        }
    }
}
