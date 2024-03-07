namespace E_Commerce.PB.Web.Models
{
    public class CarrinhoDetalheViewModel
    {
        public long? Id { get; set; }
        public long CarrinhoCabecalhoId { get; set; }
        public CarrinhoCabecalhoViewModel CarrinhoCabecalho { get; set; }
        public long ProdutotId { get; set; }
        public ProdutoViewModel Produto { get; set; }
        public int Contar { get; set; }
    }
}
