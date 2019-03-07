using System;
using System.Collections.Generic;
using System.Linq;
using CustomerAppDAL.Content;
using CustomerAppDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAppDAL.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        CustomerAppContext _context;
        public CustomerRepository(CustomerAppContext context)
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
            return _context.Customers
                .Include(c => c.Addresses)   //Making a join between customers and all his addresses to get all addresses for each customer
                .FirstOrDefault(x => x.Id == Id);
        }


        public List<Customer> GetAll()
        {
            /* With this type of return  we get all customers, and for each customer we get all his addresses, and for every address we get full information
            return _context.Customers
                .Include(c => c.Addresses)   //Making a join between customers and all his addresses to get all addresses for each customer
                .ThenInclude(ca => ca.Address)   //Making a join between customers and address to get every information for each address
                .ToList(); */


            return _context.Customers
                .Include(c => c.Addresses)   //Making a join between customers and all his addresses to get all addresses for each customer
                .ToList();
        }
    }
}
