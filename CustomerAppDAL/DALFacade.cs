using CustomerAppDAL.Repositories;
using CustomerAppDAL.Content;
using CustomerAppDAL.UOW;

namespace CustomerAppDAL
{
    public class DALFacade
    {
        //the only access point through DAL Facade is through Unit of Work
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }
        }
    }
}
