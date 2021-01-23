using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBus.Server.Consumer
{
    public class QueueConsumer : BaseConsumer
    {
        private readonly String queueName;

        public QueueConsumer(String ConnectionString, String QueueName): base(ConnectionString)
        {
            queueName = QueueName;
        }

        public override IReceiverClient CreateListener()
        {
            return new QueueClient(ConnectionString, queueName);
        }
    }
}
