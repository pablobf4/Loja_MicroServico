using System.ComponentModel.DataAnnotations.Schema;
using E_Commerce.PB.CarrinhoAPI.Model.Base;

namespace E_Commerce.PB.CarrinhoAPI.Model
{
    [Table("carrinho_detalhe")]
    public class CarrinhoDetalhe : BaseEntity
    {
        public long CarrinhoCabecalhoId { get; set; }

        [ForeignKey("CarrinhoCabecalhoId")]
        public virtual CarrinhoCabecalho CarrinhoCabecalho { get; set; }
        public long ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

        [Column("Contar")]
        public int Contar { get; set; }
    }
}
