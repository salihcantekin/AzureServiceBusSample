using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using ServiceBus.Server.Services;
using ServiceBus.Shared;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Server
{
    class Program
    {
        private readonly static String connectionString = "<YOUR CONNECTION STRING FOR EVENT BUS>";
        private readonly static String queueName = "examplequeue";
        private readonly static String topicName = "exampletopic";
        private readonly static String topicUserSubscriptionName = "user";
        private readonly static String topicOrderSubscriptionName = "order";

        static void Main(string[] args)
        {
            var queue = ConsumerFactory.CreateQueueConsumer(connectionString, queueName);
            queue.OnMessageReceived += (sender, e) =>
            {
                Console.WriteLine($"Message Received from {queueName}: " + e.MessageAsJson);
            };

            var userConsumer = ConsumerFactory.CreateTopicConsumer(connectionString, topicName, topicUserSubscriptionName);
            userConsumer.OnMessageReceived += (sender, e) =>
            {
                var userDto = JsonConvert.DeserializeObject<UserDTO>(e.MessageAsJson);
                Console.WriteLine($"Message Received from {e.Message.UserProperties["messageType"]}: " + userDto.FullName);
            };

            var orderConsumer = ConsumerFactory.CreateTopicConsumer(connectionString, topicName, topicOrderSubscriptionName);
            orderConsumer.OnMessageReceived += (sender, e) =>
            {
                var orderDTO = JsonConvert.DeserializeObject<OrderDTO>(e.MessageAsJson);
                Console.WriteLine($"Message Received from {e.Message.UserProperties["messageType"]}: " + orderDTO.Name);
            };

            userConsumer.StartListening();
            orderConsumer.StartListening();
            queue.StartListening();

            Console.ReadLine();
        }


    }
}
