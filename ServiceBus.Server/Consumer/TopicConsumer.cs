using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBus.Server.Consumer
{
    class TopicConsumer : BaseConsumer
    {
        private readonly String topicName;
        private readonly String subScriptionName;

        public TopicConsumer(String ConnectionString, string TopicName, string SubScriptionName):base(ConnectionString)
        {
            topicName = TopicName;
            subScriptionName = SubScriptionName;
        }

        public override IReceiverClient CreateListener()
        {
            return new SubscriptionClient(ConnectionString, topicName, subScriptionName);
        }
    }
}
