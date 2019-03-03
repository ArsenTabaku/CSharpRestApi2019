using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.Entities
{
    //should be public in way to be accessible from CustomerAppUI
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
