using System;
using System.Collections.Generic;
using System.Text;


namespace CustomerAppDAL
{
    //IDisposable means that when you are implementing this interface you also need to implement the dispose function
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get;  }
        int Complete();
    }
}
