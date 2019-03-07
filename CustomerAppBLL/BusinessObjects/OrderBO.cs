using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL.BusinessObjects
{
    public class OrderBO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        //each order has one customer
        public CustomerBO Customer { get; set; }

        //adding id in way to display for each order only the customer's id, not any more data
        public int CustomerId { get; set; }
    }
}
