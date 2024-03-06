using GeekShooping.CartAPI.Data.DTO;

namespace E_Commerce.PB.CarrinhoAPI.Data.DTO
{
    public class CarrinhoDTO
    {
        public CarrinhoCabecalhoDTO CarrinhoCabecalho { get; set; }

        public IEnumerable<CarrinhoDetalheDTO> CarrinhoDetalhe { get; set; }
    }
}
