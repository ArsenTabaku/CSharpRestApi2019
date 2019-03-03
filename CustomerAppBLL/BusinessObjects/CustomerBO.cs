using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL.BusinessObjects
{
    //should be public in way to be accessible from CustomerAppUI
    public class CustomerBO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        //we came up in the middle of coding that we need this property
        public string FullName
        {
            get { return $"{FirstName} { LastName}"; }
        }
    }
}
