using System.Threading.Tasks;

namespace E_Commerce.PB.MessageBus
{
    public interface IMessageBus
    {
        Task PublicMessage(BaseMessage message, string queueName);
    }
}
