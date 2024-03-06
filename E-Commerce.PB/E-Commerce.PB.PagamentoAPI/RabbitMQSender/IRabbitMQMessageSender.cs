
using E_Commerce.PB.MessageBus;

namespace E_Commerce.PB.PagamentoAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage);
    }
}
