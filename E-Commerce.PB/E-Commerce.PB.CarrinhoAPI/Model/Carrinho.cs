using E_Commerce.PB.CarrinhoAPI.Model.Base;

namespace E_Commerce.PB.CarrinhoAPI.Model
{
    public class Carrinho : BaseEntity
    {
        public CarrinhoCabecalho CarrinhoCabecalho { get; set; }

        public IEnumerable<CarrinhoDetalhe> CarrinhoDetalhe { get; set; } = new List<CarrinhoDetalhe>();
    }
}
