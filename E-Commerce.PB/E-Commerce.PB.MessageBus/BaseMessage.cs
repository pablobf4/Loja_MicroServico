using System;

namespace E_Commerce.PB.MessageBus { 
    public class BaseMessage
    {
        public long Id { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}
