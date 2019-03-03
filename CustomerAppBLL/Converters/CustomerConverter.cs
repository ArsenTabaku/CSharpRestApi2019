using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL.Converters
{
    class CustomerConverter
    {
        //this converts customer from repository to a customerBO
        internal Customer Convert(CustomerBO cust)
        {
            return new Customer()
            {
                Id = cust.Id,
                Address = cust.Address,
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }


        //this converts a customerBO to a customer in the repository
        internal CustomerBO Convert(Customer cust)
        {
            return new CustomerBO()
            {
                Id = cust.Id,
                Address = cust.Address,
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }
    }
}
