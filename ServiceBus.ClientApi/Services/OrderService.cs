using ServiceBus.ClientApi.Services.Infrastructure;
using ServiceBus.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMessagePublisher messagePublisher;

        public OrderService(IMessagePublisher MessagePublisher)
        {
            messagePublisher = MessagePublisher;
        }

        public async Task CreateOrder(OrderDTO Order)
        {
            // user creation in DB
            Console.WriteLine("Order Created on Database");


            //await messagePublisher.PublishQueue(Order);
            await messagePublisher.PublishTopic(Order);
        }
    }
}
