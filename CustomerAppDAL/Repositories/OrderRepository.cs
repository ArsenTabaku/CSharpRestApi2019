using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAL.Content;
using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppDAL.Repositories
{
    class OrderRepository : IOrderRepository
    {
        CustomerAppContext _context;
        public OrderRepository(CustomerAppContext context)
        {
            _context = context;
        }

        //What a create function does in terms of unit of work is: it prepares to save all these changes of creating new order
        //but it wont save these until the "Create" function at CustomerService will do uow.Complete();
        public Order Create(Order order)
        {
            _context.Orders.Add(order);
            return order;
        }


        public Order Delete(int Id)
        {
            var order = Get(Id);
            _context.Orders.Remove(order);
            return order;
        }


        public Order Get(int Id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == Id);
        }


        public List<Order> GetAll()
        {
            /*inlcude allows to get all the data about the customer inside the order
            return _context.Orders.Include(o => o.Customer).ToList();*/

            return _context.Orders.ToList();
        }
    }
}
