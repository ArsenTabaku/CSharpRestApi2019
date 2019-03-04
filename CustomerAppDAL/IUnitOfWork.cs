using System;


namespace CustomerAppDAL
{
    //IDisposable means that when you are implementing this interface you also need to implement the dispose function
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get;  }
        IOrderRepository OrderRepository { get; }

        int Complete();
    }
}
