using CustomerAppDAL.Repositories;
using CustomerAppDAL.Content;
using CustomerAppDAL.UOW;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        //With a property
        public ICustomerRepository CustomerRepository
        {
            get
            {
                return new CustomerRepositoryEFMemory(
                    new InMemoryContext());  //this line should be Context.InMemoryContext()
            }
        }



        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWorkMem();
            }
        }
    }
}
