﻿using ServiceBus.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Services.Infrastructure
{
    public interface IOrderService
    {
        Task CreateOrder(OrderDTO User);
    }
}
