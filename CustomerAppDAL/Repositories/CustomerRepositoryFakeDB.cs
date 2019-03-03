using CustomerAppDAL.Entities;
using System.Collections.Generic;
using System.Linq;

//this repository is going to work with a fake db, where is stored the list of customers
namespace CustomerAppDAL.Repositories
{
    class CustomerRepositoryFakeDB : ICustomerRepository
    {
        #region Fake DB
        //variables will be private because also in a real database you should not be allowed to access these from outside 
        private static List<Customer> Customers = new List<Customer>();
        private static int Id = 1;
        #endregion


        public Customer Create(Customer c)
        {
            Customer newCust;
            Customers.Add(newCust = new Customer()
            {
                Id = Id++,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address
            });
            return newCust;
        }

        public Customer Delete(int Id)
        {
            var cust = Get(Id);
            Customers.Remove(cust);
            return cust;
        }

        public Customer Get(int Id)
        {
            return Customers.FirstOrDefault(x => x.Id == Id);
        }

        public List<Customer> GetAll()
        {
            return new List<Customer>(Customers);
        }
    }
}
