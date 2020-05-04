using RealEstate.Domain.Admin;
using RealEstate.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstate.Domain.Estate
{
   public class Estates:BaseEntity
    {
        public Estates()
        {

        } 
        public int EstateStatusId { get; set; }
        public string Title { get; set; }
        public Int64 Price { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public int Baths { get; set; }
        public int Beds { get; set; }
        public int Garages { get; set; }
        public string EstateLogo { get; set; }
        public string AboutText { get; set; }
        [ForeignKey("EstateStatusId")]
        public EstateStatus EstateStatus { get; set; }
        public ICollection<RequestEstate> RequestEstates { get; set; }
        public ICollection<EstateContract> EstateContracts { get; set; }

    }
}
