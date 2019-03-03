using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;
using CustomerAppDAL;
using CustomerAppDAL.Entities;

//this is the service we are going to use to start working with customers
namespace CustomerAppBLL.Services     //this means that this class is under CustomerAppBLL/Services
{
    class CustomerService : ICustomerService
    {
        //using the CustomerConverter class we just created in the folder Converters
        CustomerConverter conv = new CustomerConverter();


        DALFacade facade;
        public CustomerService(DALFacade facade)
        {
            this.facade = facade;
        }
         

        public CustomerBO Create(CustomerBO c)
        {
            using (var uov = facade.UnitOfWork)
            {
                var newCust = uov.CustomerRepository.Create(conv.Convert(c));
                uov.Complete();
                return conv.Convert(newCust);    //converting the customer that we created in repository to a´customerBO
            }            
        }


        
        public CustomerBO Delete(int Id)
        {
            using (var uov = facade.UnitOfWork)
            {
                var newCust = uov.CustomerRepository.Delete(Id);
                uov.Complete();
                return conv.Convert(newCust);
            }
        }



        public CustomerBO Get(int Id)
        {
            using (var uov = facade.UnitOfWork)
            {
                return conv.Convert(uov.CustomerRepository.Get(Id));
            }
        }



        public List<CustomerBO> GetAll()
        {
            using (var uov = facade.UnitOfWork)
            {
                //Convert each of the items inside the list of Customer to a CustomerBO and when we are done we will return everything as a list
                return uov.CustomerRepository.GetAll().Select(c => conv.Convert(c)).ToList();
            }
        }



        public CustomerBO Update(CustomerBO c)
        {
            using (var uow = facade.UnitOfWork)
            {
                var customerFromDb = uow.CustomerRepository.Get(c.Id);
                if (customerFromDb == null)
                {
                    throw new InvalidOperationException("Customer not found!");
                }
                customerFromDb.FirstName = c.FirstName;
                customerFromDb.LastName = c.LastName;
                customerFromDb.Address = c.Address;
                uow.Complete();
                return conv.Convert(customerFromDb);
            }
            
        }


       
    }
}
