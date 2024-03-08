namespace E_Commerce.PB.OrdemAPI.Messages
{
    public class CarrinhoDetalheVO
    {
        public long Id { get; set; }
        public long CarrinhoCabecalhoId { get; set; }
        public long ProdutotId { get; set; }
        public virtual ProdutoVO Produto { get; set; }

        public int Contar { get; set; }
    }
}
