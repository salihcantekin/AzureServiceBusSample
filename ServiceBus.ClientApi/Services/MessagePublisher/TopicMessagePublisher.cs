using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using ServiceBus.ClientApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Services.MessagePublisher
{
    public class TopicMessagePublisher : Infrastructure.BaseMessagePublisher<IQueueClient>
    {
        private readonly string connectionString;
        private readonly string subScriptionName;

        public TopicMessagePublisher(String ConnectionString, String SubscriptionName)
        {
            connectionString = ConnectionString;
            subScriptionName = SubscriptionName;
        }

        protected override ISenderClient CreateClient()
        {
            return new TopicClient(connectionString, subScriptionName);
        }
    }
}
