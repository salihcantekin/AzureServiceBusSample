using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Services.Infrastructure
{
    public interface IMessagePublisher
    {
        Task PublishQueue(String MessageAsJson, String MessageType = "");

        Task PublishQueue<T>(T Message);



        Task PublishTopic<T>(T Message);

        Task PublishTopic(String MessageAsJson, String TopicName, String MessageType = "");
    }
}
