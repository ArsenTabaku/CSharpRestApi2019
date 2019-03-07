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
        AddressConverter aConv = new AddressConverter();

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


        public void CreateAll(List<CustomerBO> c)
        {
            using (var uov = facade.UnitOfWork)
            {
                //data are stored in memory only after the foreach has finished (all customers are created)
                foreach (var customer in c)
                {
                    var newCust = uov.CustomerRepository.Create(conv.Convert(customer));
                }
                uov.Complete();
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
                //1. Get and convert the customer
                var cust = conv.Convert(uov.CustomerRepository.Get(Id));

                //2. Get all related addresses from AddressRepository using address id
                //3. Convert and Add the Addresses to te CustomerBO

                //-----FIRST WAY-----
                /*cust.Addresses = cust.AddressIds?
                     .Select(id => aConv.Convert(uov.AddressRepository.Get(Id)))
                     .ToList();*/


                //----SECOND WAY----This way avoids making request for each customer, but instead makes one request
                cust.Addresses = uov.AddressRepository.GetAllById(cust.AddressIds)
                    .Select(a => aConv.Convert(a))
                    .ToList();

                return cust;
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
                var customerUpdated = conv.Convert(c);
                customerFromDb.FirstName = customerUpdated.FirstName;
                customerFromDb.LastName = customerUpdated.LastName;
                customerFromDb.Address = customerUpdated.Address;

                //1. Remove every customerId and AddressId that does not exists in DBContext
                customerFromDb.Addresses.RemoveAll(
                    ca => !customerUpdated.Addresses.Exists(
                        a => a.AddressId == ca.AddressId &&
                        a.CustomerId == ca.CustomerId));

                //2. Remove all ids that are already in database
                customerUpdated.Addresses.RemoveAll(
                    ca => customerFromDb.Addresses.Exists(
                        a => a.AddressId == ca.AddressId &&
                        a.CustomerId == ca.CustomerId));

                //3. Add all new customerAddresses not yet seen in the DB
                customerFromDb.Addresses.AddRange(
                    customerUpdated.Addresses);

                uow.Complete();
                return conv.Convert(customerFromDb);
            }
        }


       
    }
}
