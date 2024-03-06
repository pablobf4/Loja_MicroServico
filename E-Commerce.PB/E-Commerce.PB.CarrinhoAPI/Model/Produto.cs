using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using E_Commerce.PB.CarrinhoAPI.Model.Base;

namespace E_Commerce.PB.CarrinhoAPI.Model
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
