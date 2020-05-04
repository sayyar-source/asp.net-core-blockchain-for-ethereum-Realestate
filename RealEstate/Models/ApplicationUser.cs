using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Web.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string cellphoneNo { get; set; }
        //etherum address
        public string EthAccountAddress { get; set; }
        //alan/satan/danisman
        public bool IsConsulant { get; set; }
    }
}
