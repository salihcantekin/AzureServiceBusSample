using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBus.ClientApi.Services.Infrastructure;
using ServiceBus.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBus.ClientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService OrderService)
        {
            orderService = OrderService;
        }

        [HttpGet]
        public String Get()
        {
            return "OK";
        }

        [HttpPost]
        public async Task Create(OrderDTO Order)
        {
            await orderService.CreateOrder(Order);
        }
    }
}
