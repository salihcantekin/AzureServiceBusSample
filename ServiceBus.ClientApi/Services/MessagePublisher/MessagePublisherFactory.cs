using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Services.MessagePublisher
{
    public static class MessagePublisherFactory
    {
        private static readonly ConcurrentDictionary<String, QueueMessagePublisher> queueMessagePublisherDict;
        private static readonly ConcurrentDictionary<String, TopicMessagePublisher> topicMessagePublisherDict;

        static MessagePublisherFactory()
        {
            queueMessagePublisherDict = new ConcurrentDictionary<string, QueueMessagePublisher>();
            topicMessagePublisherDict = new ConcurrentDictionary<string, TopicMessagePublisher>();
        }

        public static QueueMessagePublisher CreateQueueMessagePublisher(String ConnectionName, String QueueName)
        {
            if (queueMessagePublisherDict.ContainsKey(QueueName))
                return queueMessagePublisherDict[QueueName];

            var q = new QueueMessagePublisher(ConnectionName, QueueName);
            queueMessagePublisherDict.TryAdd(QueueName, q);

            return q;
        }

        public static TopicMessagePublisher CreateTopicMessagePublisher(String ConnectionName, String SubscriptionName)
        {
            if (topicMessagePublisherDict.ContainsKey(SubscriptionName))
                return topicMessagePublisherDict[SubscriptionName];

            var t = new TopicMessagePublisher(ConnectionName, SubscriptionName);
            topicMessagePublisherDict.TryAdd(SubscriptionName, t);

            return t;
        }

    }
}
