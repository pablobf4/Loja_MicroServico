using E_Commerce.PB.OrdemAPI.Modell;

namespace E_Commerce.PB.OrdemAPI.Repository
{
    public interface IOrdemRepository
    {
        Task<bool> AddOrder(OrdemCabecalho header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);
    }
}
