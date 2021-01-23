using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public String Get()
        {
            return "OK";
        }

        [HttpPost]
        public async Task Create(UserDTO User)
        {
            await userService.CreateUser(User);
        }
    }
}
