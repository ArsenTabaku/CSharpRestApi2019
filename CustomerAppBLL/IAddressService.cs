using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    public interface IAddressService
    {
        //Create
        AddressBO Create(AddressBO address);

        //Read
        List<AddressBO> GetAll();
        AddressBO Get(int Id);

        //Update
        AddressBO Update(AddressBO address);

        //Delete
        AddressBO Delete(int Id);
    }
}
