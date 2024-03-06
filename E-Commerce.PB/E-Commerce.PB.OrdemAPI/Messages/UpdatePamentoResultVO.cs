using E_Commerce.PB.MessageBus;

namespace E_Commerce.PB.OrdemAPI.Messages
{
    public class UpdatePamentoResultVO : BaseMessage
    {
        public long OrderId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}
