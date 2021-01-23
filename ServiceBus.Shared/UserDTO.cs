using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBus.Shared
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String FullName => $"{FirstName} {LastName}";
    }
}
