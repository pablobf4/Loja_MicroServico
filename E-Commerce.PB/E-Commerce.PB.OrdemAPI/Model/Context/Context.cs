using E_Commerce.PB.OrdemAPI.Modell;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.PB.OrdemAPI.Model.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<OrdemDetalhe> OrdemDetalhes { get; set; }
        public DbSet<OrdemCabecalho> OrdemCabecalhos { get; set; }
    }
}