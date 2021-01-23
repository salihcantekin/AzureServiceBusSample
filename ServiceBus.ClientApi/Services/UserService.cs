using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using ServiceBus.ClientApi.Services.Infrastructure;
using ServiceBus.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMessagePublisher messagePublisher;

        public UserService(IMessagePublisher MessagePublisher)
        {
            messagePublisher = MessagePublisher;
        }

        public async Task CreateUser(UserDTO User)
        {
            // user creation in DB
            Console.WriteLine("User Created on Database");


            //await messagePublisher.PublishQueue(User);
            await messagePublisher.PublishTopic(User);
        }

    }
}
