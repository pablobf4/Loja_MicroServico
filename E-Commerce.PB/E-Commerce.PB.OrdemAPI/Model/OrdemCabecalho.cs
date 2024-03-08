
using E_Commerce.PB.MessageBus;
using E_Commerce.PB.OrdemAPI.Model;
using E_Commerce.PB.OrdemAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace E_Commerce.PB.OrdemAPI.Modell
{
    [Table("Ordem_Cabecalho")]
    public class OrdemCabecalho : BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; }

        [Column("coupon_code")]
        public string? CupomCodigo { get; set; }

        [Column("valor_compra")]
        public decimal ValorCompra { get; set; }

        [Column("valor_desconto")]
        public decimal ValorDesconto { get; set; }

        [Column("primeiro_name")]
        public string PrimeiroNome { get; set; }

        [Column("sobrenome_name")]
        public string Sobrenome { get; set; }

        [Column("purchase_date")]
        public DateTime DataCompra { get; set; }

        [Column("ordem_time")]
        public DateTime HoraPedido { get; set; }

        [Column("telefone_number")]
        public string Telefone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("numero_cartao")]
        public string NumeroCartao { get; set; }

        [Column("cvv")]
        public string CVV { get; set; }

        [Column("expiracao_mes_ano")]
        public string MesAnoExpiracao { get; set; }

        [Column("total_itens")]
        public int TotalItensCarrinho { get; set; }

        public List<OrdemDetalhe> DetalhesPedido { get; set; }

        [Column("pagamento_status")]
        public bool StatusPagamento { get; set; }

        public static explicit operator OrdemCabecalho(BaseMessage v)
        {
            throw new NotImplementedException();
        }
    }
}
