namespace E_Commerce.PB.ProdutoAPI.Data.DTO
{
    public class ProdutoDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string CategoriaNome { get; set; }

        public string ImageUrl { get; set; }

    }
}
