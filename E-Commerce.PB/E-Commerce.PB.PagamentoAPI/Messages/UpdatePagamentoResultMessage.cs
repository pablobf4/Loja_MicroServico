
using E_Commerce.PB.MessageBus;

namespace E_Commerce.PB.PagamentoAPI.Messages
{
    public class UpdatePagamentoResultMessage : BaseMessage
    {
        public long OrderId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}
