
using E_Commerce.PB.CarrinhoAPI.Data.DTO;
using E_Commerce.PB.MessageBus;

namespace E_Commerce.PB.CarrinhoAPI.Menssages
{
    public class CheckoutHeaderVO : BaseMessage
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CuponCode { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorDesconto { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public DateTime Data { get; set; }
        public string Titulo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CarrinhoNumero { get; set; }
        public string CVV { get; set; }
        public string ExpiracaoMesAno { get; set; }
        public int CarrinhoTotalItens { get; set; }
        public IEnumerable<CarrinhoDetalheDTO> CarrinhoDetalhe { get; set; }
    }
}
