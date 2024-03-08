
using E_Commerce.PB.MessageBus;

namespace E_Commerce.PB.OrdemAPI.Messages
{
    public class CheckoutHeaderVO : BaseMessage
    {
        public string UserId { get; set; }
        public string CuponCode { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorDesconto { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Data { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string NumeroCarrinho { get; set; }
        public string CVV { get; set; }
        public string ExpiracaoMesAno { get; set; }

        public int CarrinhoTotalItens { get; set; }
        public IEnumerable<CarrinhoDetalheVO> CarrinhoDetalhe { get; set; }
    }
}