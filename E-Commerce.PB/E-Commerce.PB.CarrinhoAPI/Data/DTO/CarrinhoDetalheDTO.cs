
using GeekShooping.CartAPI.Data.DTO;

namespace E_Commerce.PB.CarrinhoAPI.Data.DTO
{
    public class CarrinhoDetalheDTO 
    {
        public long Id { get; set; }
        public long CarrinhoCabecalhoId { get; set; }
        public CarrinhoCabecalhoDTO? CarrinhoCabecalho { get; set; }
        public long ProductId { get; set; }
        public ProdutoDTO Produto { get; set; }
        public int Conta { get; set; }
    }
}
