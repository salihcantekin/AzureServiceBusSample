using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Utils
{
    public class ServiceBusConfig
    {
        public String QueueName { get; set; }

        public String ConnectionString { get; set; }

        public String TopicName { get; set; }

    }
}
