using System;
using System.Collections.Generic;
using System.Linq;
using CustomerAppDAL.Content;
using CustomerAppDAL.Entities;

namespace CustomerAppDAL.Repositories
{
    class CustomerRepositoryEFMemory : ICustomerRepository
    {
        CustomerAppContext _context;
        public CustomerRepositoryEFMemory(CustomerAppContext context)
        {
            _context = context;
        }


        //create a customer in our in memory database
        public Customer Create(Customer c)
        {
            //add the customer c to the table Customers
            _context.Customers.Add(c);
            return c;
        }

        public Customer Delete(int Id)
        {
            var cust = Get(Id);
            _context.Customers.Remove(cust);
            return cust;
        }


        public Customer Get(int Id)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == Id);
        }


        public List<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
