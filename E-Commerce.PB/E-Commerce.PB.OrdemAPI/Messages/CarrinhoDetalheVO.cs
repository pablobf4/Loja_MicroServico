namespace E_Commerce.PB.OrdemAPI.Messages
{
    public class CarrinhoDetalheVO
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public long ProductId { get; set; }
        public virtual ProdutoVO Product { get; set; }

        public int Count { get; set; }
    }
}
