using CustomerAppBLL.Services;
using CustomerAppDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    //it is public because it is going to be accessed from other projects
    public class BLLFacade
    {
         //With a property
         public ICustomerService CustomerService
        {
            get { return new CustomerService(new DALFacade()); }
        }
    }
}
