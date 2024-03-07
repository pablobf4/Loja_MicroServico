
using GeekShooping.CartAPI.Data.DTO;

namespace E_Commerce.PB.CarrinhoAPI.Data.DTO
{
    public class CarrinhoDetalheDTO 
    {
        public long? Id { get; set; }
        public long? CarrinhoCabecalhoId { get; set; }
        public CarrinhoCabecalhoDTO? CarrinhoCabecalho { get; set; }
        public long ProdutotId { get; set; }
        public ProdutoDTO Produto { get; set; }
        public int Contar { get; set; }
    }
}
