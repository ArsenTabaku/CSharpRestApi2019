using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;
using CustomerAppDAL;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.Services
{
    class AddressService : IAddressService
    {
        AddressConverter conv;
        DALFacade _facade;

        public AddressService(DALFacade facade)
        {
            _facade = facade;
            conv = new AddressConverter();
        }


        public AddressBO Create(AddressBO address)
        {
            using (var uow = _facade.UnitOfWork)  //enter the access to database
            {
                var addressEntity = uow.AddressRepository.Create(conv.Convert(address));   //create a order
                uow.Complete();   //save changes
                return conv.Convert(addressEntity);
            }
        }

        public AddressBO Delete(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var addressEntity = uow.AddressRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(addressEntity);
            }
        }



        public AddressBO Get(int Id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var addressEntity = uow.AddressRepository.Get(Id);
                //addressEntity.Id = uow.CustomerRepository.Get(addressEntity.Id);    //get all customer information when getting a specific order
                return conv.Convert(uow.AddressRepository.Get(Id));
            }
        }


        public List<AddressBO> GetAll()
        {
            //use of landa expression
            using (var uow = _facade.UnitOfWork)
            {
                return uow.AddressRepository.GetAll().Select(o => conv.Convert(o)).ToList();
                //SECOND WAY - return uow.OrderRepository.GetAll().Select(conv.Convert).ToList();
            }
        }


        public AddressBO Update(AddressBO address)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var addressEntity = uow.AddressRepository.Get(address.Id);
                if (addressEntity == null)
                {
                    throw new InvalidOperationException("Order not found!");
                }
                addressEntity.City = address.City;
                addressEntity.Street = address.Street;
                addressEntity.Number = address.Number;
                uow.Complete();
                //addressEntity.Id = uow.CustomerRepository.Get(addressEntity.Id);  /*this makes possible that when you update one order,
                //the customerID you updated will be also updated for the real customer and once you make the request, his data will be appeared*/
                return conv.Convert(addressEntity);
            }
        }
    }
}
