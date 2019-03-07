using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerAppDAL.Content;
using CustomerAppDAL.Entities;

namespace CustomerAppDAL.Repositories
{
    class AddressRepository : IAddressRepository
    {
        CustomerAppContext _context;
        public AddressRepository(CustomerAppContext context)
        {
            _context = context;
        }


        public Address Create(Address address)
        {
            _context.Addresses.Add(address);
            return address;
        }


        public Address Delete(int Id)
        {
            var address = Get(Id);
            _context.Addresses.Remove(address);
            return address;
        }


        public Address Get(int Id)
        {
            return _context.Addresses.FirstOrDefault(a => a.Id == Id);
        }


        public List<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }


        public IEnumerable<Address> GetAllById(List<int> ids)
        {
            if (ids == null) return null;
            return _context.Addresses.Where(a => ids.Contains(a.Id));  //check if address id is inside the list of addresses
        }
    }
}
