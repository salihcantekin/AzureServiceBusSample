using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using ServiceBus.ClientApi.Services.MessagePublisher.Infrastructure;
using ServiceBus.ClientApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Services.MessagePublisher
{
    public class QueueMessagePublisher: Infrastructure.BaseMessagePublisher<IQueueClient>
    {
        private readonly string connectionString;
        private readonly string queueName;

        public QueueMessagePublisher(String ConnectionString, String QueueName)
        {
            connectionString = ConnectionString;
            queueName = QueueName;
        }

        protected override ISenderClient CreateClient()
        {
            return new QueueClient(connectionString, queueName);
        }
    }
}
