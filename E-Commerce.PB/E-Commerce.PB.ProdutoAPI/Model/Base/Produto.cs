using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.PB.ProdutoAPI.Model.Base
{
    [Table("produto")]
    public class Produto : BaseEntity
    {
        [Column("nome")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }


        [Column("preco")]
        [Required]
        [Range(1, 100000000)]
        public decimal Preco { get; set; }

        [Column("descricao")]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Column("categoria_nome")]
        [StringLength(50)]
        public string CategoriaNome { get; set; }

        [Column("image_url")]
        [StringLength(300)]
        public string ImageUrl { get; set; }

    }
}
