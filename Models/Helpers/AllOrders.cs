using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Your_IoT_Handprint.Models.Helpers
{
    public class AllOrders
    {
        public List<Order> MyOrders { get; set; }

        public List<Order> OrdersToDeliver { get; set; }
    }
}