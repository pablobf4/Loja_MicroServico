

using E_Commerce.PB.MessageBus;

namespace E_Commerce.PB.OrdemAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
