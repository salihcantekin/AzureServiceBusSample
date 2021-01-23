using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Services.MessagePublisher.Infrastructure
{
    public abstract class BaseMessagePublisher<T> where T: ISenderClient
    {
        private ISenderClient _client;
        protected ISenderClient Client => _client ??= CreateClient();

        protected abstract ISenderClient CreateClient();

        public virtual Task Publish<TObject>(TObject Message)
        {
            String userAsJson = JsonConvert.SerializeObject(Message);

            return Publish(userAsJson, typeof(TObject).Name);
        }

        public virtual Task Publish(string MessageAsJson, string MessageType = "")
        {
            var jsonAsByteArr = Encoding.UTF8.GetBytes(MessageAsJson);

            var message = new Message(jsonAsByteArr);
            message.UserProperties["messageType"] = MessageType;
            
            return Client.SendAsync(message);
        }

    }
}
