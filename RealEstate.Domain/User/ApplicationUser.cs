using Microsoft.AspNetCore.Identity;
using RealEstate.Domain.Estate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Domain.User
{
   public class ApplicationUser: IdentityUser
    {
        // Extended Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EthAccountAddress { get; set; }
        public string PictureUrl { get; set; }
        public string JobType { get; set; }
        public ICollection<RequestEstate> RequestEstates { get; set; }
        public ICollection<EstateContract> EstateContracts { get; set; }
    }
}
