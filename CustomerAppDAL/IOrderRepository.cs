using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public interface IOrderRepository
    {
        //Create
        Order Create(Order c);

        //Read
        List<Order> GetAll();
        Order Get(int id);

        //Delete
        Order Delete(int Id);
    }
}
