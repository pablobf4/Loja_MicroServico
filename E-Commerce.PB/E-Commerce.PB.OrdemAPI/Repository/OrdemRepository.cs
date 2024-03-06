
using E_Commerce.PB.OrdemAPI.Model.Context;
using E_Commerce.PB.OrdemAPI.Modell;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.PB.OrdemAPI.Repository
{
    public class OrdemRepository : IOrdemRepository
    {
        private readonly DbContextOptions<Context> _context;

        public OrdemRepository(DbContextOptions<Context> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrdemCabecalho header)
        {
            if(header == null) return false;
            await using var _db = new Context(_context);
            _db.OrdemCabecalhos.Add(header);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            await using var _db = new Context(_context);
            var header = await _db.OrdemCabecalhos.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            if (header != null)
            {
                header.StatusPagamento = status;
                await _db.SaveChangesAsync();
            };
        }
    }
}
