using CustomerAppBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    public interface IOrderService
    {
        //Create
        OrderBO Create(OrderBO c);

        //Read
        List<OrderBO> GetAll();
        OrderBO Get(int Id);

        //Update
        OrderBO Update(OrderBO c);

        //Delete
        OrderBO Delete(int Id);
    }
}
