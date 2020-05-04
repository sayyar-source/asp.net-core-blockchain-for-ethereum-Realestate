using RealEstate.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Domain
{
   public class UserViewModel:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public string IdentityId { get;  set; }
        public string UserName { get;  set; } // Required by automapper
        public string Email { get;  set; }
        public string PhoneNumber { get; set; }
        public string Password { get;  set; }
        public string JobType { get; set; }
                                          

    }
}
