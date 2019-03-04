using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerAppBLL.BusinessObjects
{
    //should be public in way to be accessible from CustomerAppUI
    public class CustomerBO
    {

        public int Id { get; set; }

        [Required]  //this means that you cannot create an object without a first name
        [MaxLength(20)]  //first name cannot be longer than 20 characters
        [MinLength(3)]   //first name cannot be shorter than 3 characters
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
