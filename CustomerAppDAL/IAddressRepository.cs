using CustomerAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL
{
    public interface IAddressRepository
    {
        //Create
        Address Create(Address address);

        //Read
        List<Address> GetAll();

        IEnumerable<Address> GetAllById(List<int> ids);

        Address Get(int Id);

        //Delete
        Address Delete(int Id);
    }
}
