using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.PB.OrdemAPI.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiroMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordem_Cabecalho",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coupon_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valor_compra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    primeiro_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sobrenome_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purchase_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ordem_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telefone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero_cartao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cvv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiracao_mes_ano = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_itens = table.Column<int>(type: "int", nullable: false),
                    pagamento_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem_Cabecalho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdemCabecalho = table.Column<long>(type: "bigint", nullable: false),
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false),
                    contar = table.Column<int>(type: "int", nullable: false),
                    produto_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_detail_Ordem_Cabecalho_IdOrdemCabecalho",
                        column: x => x.IdOrdemCabecalho,
                        principalTable: "Ordem_Cabecalho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_IdOrdemCabecalho",
                table: "order_detail",
                column: "IdOrdemCabecalho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_detail");

            migrationBuilder.DropTable(
                name: "Ordem_Cabecalho");
        }
    }
}
