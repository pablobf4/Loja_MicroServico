using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.PB.CarrinhoAPI.Migrations
{
    /// <inheritdoc />
    public partial class segundoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Conta",
                table: "carrinho_detalhe",
                newName: "Contar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contar",
                table: "carrinho_detalhe",
                newName: "Conta");
        }
    }
}
