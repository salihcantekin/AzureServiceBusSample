using Newtonsoft.Json;
using ServiceBus.ClientApi.Services.Infrastructure;
using ServiceBus.ClientApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Services.MessagePublisher
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly ServiceBusConfig config;

        public MessagePublisher(ServiceBusConfig Config)
        {
            config = Config;
        }

        public Task PublishQueue(string MessageAsJson, string MessageType = "")
        {
            return MessagePublisherFactory
                        .CreateQueueMessagePublisher(config.ConnectionString, config.QueueName)
                        .Publish(MessageAsJson, MessageType);
        }

        public Task PublishQueue<T>(T Message)
        {
            String messageAsJson = JsonConvert.SerializeObject(Message);
            return PublishQueue(messageAsJson, typeof(T).Name);
        }





        public Task PublishTopic<T>(T Message)
        {
            String messageAsJson = JsonConvert.SerializeObject(Message);
            return PublishTopic(messageAsJson, config.TopicName, typeof(T).Name);
        }

        public Task PublishTopic(string MessageAsJson, string TopicName, string MessageType = "")
        {
            return MessagePublisherFactory
                        .CreateTopicMessagePublisher(config.ConnectionString, config.TopicName)
                        .Publish(MessageAsJson, MessageType);
        }
    }
}
