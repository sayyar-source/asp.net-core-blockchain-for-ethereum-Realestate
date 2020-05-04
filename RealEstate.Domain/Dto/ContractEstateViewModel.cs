using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Domain.Dto
{
   public class ContractEstateViewModel
    {
        public int ContractId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerLastname { get; set; }
        public string OwnerPhone { get; set; }
        public string BuyerName { get; set; }
        public string BuyerLastname { get; set; }
        public string BuyerPhone { get; set; }
        public string SelerName { get; set; }
        public string SelerLastname { get; set; }
        public string SelerPhone { get; set; }
        public string EstateTitle { get; set; }
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public bool BuyerOk { get; set; }
        public bool SelerOk { get; set; }
        public DateTime? SelerOkTime { get; set; }
        public DateTime? BuyerOkTime { get; set; }
        public string Note { get; set; }
        public string LogoURL { get; set; }

    }
}
