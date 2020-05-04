using RealEstate.Domain.Shared;
using RealEstate.Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstate.Domain.Estate
{
   public class RequestEstate:BaseEntity
    {
     
        public string SaveUserId { get; set; }
        public int EstateId { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }

        [ForeignKey("EstateId")]
        public  Estates Estate { get; set; }
        [ForeignKey("SaveUserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
