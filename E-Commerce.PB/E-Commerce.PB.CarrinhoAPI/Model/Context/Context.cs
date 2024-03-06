using Microsoft.EntityFrameworkCore;

namespace E_Commerce.PB.CarrinhoAPI.Model.Context
{

    public class Context : DbContext
	{
		protected readonly IConfiguration Configuration;
		public Context(IConfiguration configuration) { Configuration = configuration; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Server=NOC05\\SQLEXPRESS;Database=e_commerce_carrinho;Trusted_Connection=True;TrustServerCertificate=True;");
		}
		public DbSet<CarrinhoDetalhe> CarrinhoDetalhes { get; set; }
		public DbSet<CarrinhoCabecalho> CarrinhoCabecalhos { get; set; }
		public DbSet<Produto> Produtos { get; set; }

	}
}
