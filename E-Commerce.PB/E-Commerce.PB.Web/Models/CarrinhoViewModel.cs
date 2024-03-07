using System.Collections.Generic;

namespace E_Commerce.PB.Web.Models
{
    public class CarrinhoViewModel
    {
        public CarrinhoCabecalhoViewModel CarrinhoCabecalho { get; set; }
        public IEnumerable<CarrinhoDetalheViewModel> CarrinhoDetalhe { get; set; }
    }
}
