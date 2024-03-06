using E_Commerce.PB.OrdemAPI.Model.Base;
using E_Commerce.PB.OrdemAPI.Modell;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.PB.OrdemAPI.Model
{
    [Table("order_detail")]
    public class OrdemDetalhe : BaseEntity
    {
        public long IdOrdemCabecalho { get; set; }

        [ForeignKey("IdOrdemCabecalho")]
        public virtual OrdemCabecalho OrdemCabecalho { get; set; }

        [Column("ProdutoId")]
        public long IdProduto { get; set; }

        [Column("contar")]
        public int Quantidade { get; set; }

        [Column("produto_nome")]
        public string NomeProduto { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }
    }
}
