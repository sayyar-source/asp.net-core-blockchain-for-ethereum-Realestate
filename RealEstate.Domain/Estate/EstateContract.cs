using RealEstate.Domain.Shared;
using RealEstate.Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstate.Domain.Estate
{
   public class EstateContract:BaseEntity
    {
      
        public int EstateId { get; set; }
        public string OwnerUserId { get; set; }
        public string BuyerUserId { get; set; }
        public string SellerUserId { get; set; }
        public bool BuyerOK { get; set; }
        public bool SellerOK { get; set; }
        [Column(TypeName ="smalldatetime")]
        public DateTime? BuyerOKTime { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? SellerOKTime { get; set; }
        public string Note { get; set; }
        [Display(Name ="Number Of Token")]
        public int Amount { get; set; }


        [ForeignKey("EstateId")]
        public Estates Estates { get; set; }

        [ForeignKey("OwnerUserId")]
        [InverseProperty("EstateContracts")]
        public ApplicationUser OwnerUser { get; set; }
        [ForeignKey("BuyerUserId")]
        public ApplicationUser BuyerUser { get; set; }
        [ForeignKey("SellerUserId")]
        public ApplicationUser SellerUser { get; set; }
    }
}
