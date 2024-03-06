using System.Collections.Generic;

namespace E_Commerce.PB.Web.Models
{
    public class CarrinhoViewModel
    {
        public CarrinhoCabecalhoViewModel CartCabecalho { get; set; }
        public IEnumerable<CarrinhoDetalheViewModel> CartDetalhe { get; set; }
    }
}
