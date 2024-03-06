namespace E_Commerce.PB.Web.Models
{
    public class CarrinhoDetalheViewModel
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public CarrinhoCabecalhoViewModel CartHeader { get; set; }
        public long ProductId { get; set; }
        public ProdutoViewModel Product { get; set; }

        public int Count { get; set; }
    }
}
