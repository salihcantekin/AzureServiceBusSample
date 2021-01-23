using ServiceBus.Server.Consumer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBus.Server.Services
{
    public static class ConsumerFactory
    {
        public static BaseConsumer CreateQueueConsumer(String ConnectionString, String QueueName)
        {
            return new QueueConsumer(ConnectionString, QueueName);
        }

        public static BaseConsumer CreateTopicConsumer(String ConnectionString, String TopicName, String SubscriptionName)
        {
            return new TopicConsumer(ConnectionString, TopicName, SubscriptionName);
        }
    }
}
