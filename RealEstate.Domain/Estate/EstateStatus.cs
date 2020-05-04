using RealEstate.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstate.Domain.Estate
{
   public class EstateStatus:BaseEntity
    {
        public EstateStatus()
        {

        }
        
       // public int EstateStatusId { get; set; }
        public string EstateStatusName { get; set; }
        public ICollection<Estates> Estates { get; set; }
    }
}
