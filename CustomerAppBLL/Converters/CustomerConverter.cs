using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerAppBLL.Converters
{
    class CustomerConverter
    {
        private AddressConverter aConv;
        public CustomerConverter()
        {
            aConv = new AddressConverter();
        }


        //this converts customer from repository to a customerBO
        internal Customer Convert(CustomerBO cust)
        {
            if(cust == null) { return null;  }

            return new Customer()
            {
                Id = cust.Id,
                Addresses = cust.AddressIds?.Select(aId => new CustomerAddress()
                {
                    AddressId = aId,
                    CustomerId = cust.Id
                }).ToList(),

                /*Addresses = cust.Addresses?.Select(a => new CustomerAddress(){
                    AddressId = a.Id,
                    CustomerId = cust.Id
                }).ToList(),*/
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
        }


        //this converts a customerBO to a customer in the repository
        internal CustomerBO Convert(Customer cust)
        {
            if (cust == null) { return null; }

            return new CustomerBO()
            {
                Id = cust.Id,
                AddressIds = cust.Addresses?.Select(a => a.AddressId).ToList(),    //this line converts all customer's addressIds to a customerBO's addressIds
                FirstName = cust.FirstName,
                LastName = cust.LastName
                /* IF WE WANT THAT FOR EACH CUSTOMER TO HAVE ALL INFORMATION FOR EACH OF THEIR ADDRESSES
                 * ----IF WE ADD THIS WE SHOULD ALSO ADD THE COMMENTED CODE IN CUSTOMERREPOSITORY/GETALL()----
                 * Addresses = cust.Addresses?.Select(a => new AddressBO()
                {    //grab each address and convert in an addressBO
                    Id = a.CustomerId,
                    City = a.Address?.City,
                    Number = a.Address?.Number,
                    Street = a.Address?.Street
                }).ToList(),*/
            };
        }
    }
}
