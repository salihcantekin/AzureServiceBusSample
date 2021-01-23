using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceBus.Shared
{
    public class OrderDTO
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }
    }
}
