using CustomerAppDAL.Entities;
using System.Collections.Generic;

namespace CustomerAppDAL
{
    public interface ICustomerRepository
    {
        //Create
        Customer Create(Customer c);

        //Read
        List<Customer> GetAll();
        Customer Get(int id);
        
        //Delete
        Customer Delete(int Id);

        //NOTE: No update for Repository, it will be task of unit of work
    }
}
