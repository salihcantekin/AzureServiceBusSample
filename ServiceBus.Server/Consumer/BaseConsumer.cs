using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using ServiceBus.Server.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Server.Consumer
{
    public abstract class BaseConsumer
    {
        protected String ConnectionString { get; set; }
        private IReceiverClient activeClient;


        public BaseConsumer(String ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public event EventHandler<OnMessageReceivedEventArgs> OnMessageReceived;

        public abstract IReceiverClient CreateListener();

        public void StartListening()
        {
            activeClient = CreateListener();

            activeClient.RegisterMessageHandler((message, handler) =>
            {
                OnMessageReceived?.Invoke(this, new OnMessageReceivedEventArgs(message));

                return activeClient.CompleteAsync(message.SystemProperties.LockToken);

            }, new MessageHandlerOptions(x => Task.CompletedTask));

            Console.WriteLine("Started Listening for " + this.GetType().Name);
        }

        public void StopListening()
        {
            if (!activeClient.IsClosedOrClosing)
                activeClient.CloseAsync();
        }
    }
}
