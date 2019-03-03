using CustomerAppBLL.BusinessObjects;
using System.Collections.Generic;

namespace CustomerAppBLL
{
    public interface ICustomerService
    {
        //Create
        CustomerBO Create(CustomerBO c);

        //Read
        List<CustomerBO> GetAll();
        CustomerBO Get(int id);

        //Update
        CustomerBO Update(CustomerBO c);

        //Delete
        CustomerBO Delete(int Id);
    }
}
