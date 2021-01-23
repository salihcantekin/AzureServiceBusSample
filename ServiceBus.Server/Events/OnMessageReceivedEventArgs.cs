using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBus.Server.Events
{
    public class OnMessageReceivedEventArgs: EventArgs
    {
        public OnMessageReceivedEventArgs(Message Message)
        {
            this.Message = Message;
        }

        public Message Message { get; set; }

        public string MessageAsJson => Message != null ? Encoding.UTF8.GetString(Message.Body) : String.Empty;
    }
}
