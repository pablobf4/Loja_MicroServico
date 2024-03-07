using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.PB.CarrinhoAPI.Migrations
{
    public partial class Primeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carrinho_cabecalho",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<string>(name: "user_id", type: "nvarchar(max)", nullable: false),
                    cuponcode = table.Column<string>(name: "cupon_code", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrinho_cabecalho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    categorianome = table.Column<string>(name: "categoria_nome", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    imageurl = table.Column<string>(name: "image_url", type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "carrinho_detalhe",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrinhoCabecalhoId = table.Column<long>(type: "bigint", nullable: false),
                    ProdutoId = table.Column<long>(type: "bigint", nullable: false),
                    Contar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrinho_detalhe", x => x.id);
                    table.ForeignKey(
                        name: "FK_carrinho_detalhe_carrinho_cabecalho_CarrinhoCabecalhoId",
                        column: x => x.CarrinhoCabecalhoId,
                        principalTable: "carrinho_cabecalho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carrinho_detalhe_produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carrinho_detalhe_CarrinhoCabecalhoId",
                table: "carrinho_detalhe",
                column: "CarrinhoCabecalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_carrinho_detalhe_ProdutoId",
                table: "carrinho_detalhe",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carrinho_detalhe");

            migrationBuilder.DropTable(
                name: "carrinho_cabecalho");

            migrationBuilder.DropTable(
                name: "produto");
        }
    }
}
