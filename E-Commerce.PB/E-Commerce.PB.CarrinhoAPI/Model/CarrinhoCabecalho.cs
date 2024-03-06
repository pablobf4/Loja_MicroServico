using System.ComponentModel.DataAnnotations.Schema;
using E_Commerce.PB.CarrinhoAPI.Model.Base;

namespace E_Commerce.PB.CarrinhoAPI.Model
{
    [Table("carrinho_cabecalho")]
    public class CarrinhoCabecalho : BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; }

        [Column("cupon_code")]
        public string? CuponCode { get; set; }
    }
}
