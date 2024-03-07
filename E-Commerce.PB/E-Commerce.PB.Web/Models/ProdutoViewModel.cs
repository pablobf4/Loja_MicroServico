using System.ComponentModel.DataAnnotations;

namespace E_Commerce.PB.Web.Models
{
    public class ProdutoViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string CategoriaNome { get; set; }
        public string ImageURL { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubstringName()
        {
            if (Nome.Length < 24) return Nome;
            return $"{ Nome.Substring(0, 21) } ...";
        }

        public string SubstringDescription()
        {
            if (Descricao.Length < 355) return Descricao;
            return $"{ Descricao.Substring(0, 352) } ...";
        }



    }
}
