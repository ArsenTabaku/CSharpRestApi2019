using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL.Converters
{
    class OrderConverter
    {
        //this converts order from repository to a orderBO
        internal Order Convert(OrderBO order)
        {
            if (order == null) { return null; }

            return new Order()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
                CustomerId = order.CustomerId
            };
        }


        //this converts a orderBO to a order in the repository
        internal OrderBO Convert(Order order)
        {
            if (order == null) { return null; }

            return new OrderBO()
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate,
                Customer = new CustomerConverter().Convert(order.Customer),
                CustomerId = order.CustomerId
            };
        }
    }
}
