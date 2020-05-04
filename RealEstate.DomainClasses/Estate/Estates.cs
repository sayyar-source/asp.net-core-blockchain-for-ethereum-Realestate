using RealEstate.DomainClasses.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstate.DomainClasses.Estate
{
   public class Estates
    {
        public Estates()
        {

        }
        [Key]
        public int EstateId { get; set; }
        public int neighborhoodId { get; set; }
        public int EstateStatusId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
        public decimal Area { get; set; }
        public byte RoomNo { get; set; }
        public Int16 ConstructionYear { get; set; }
        public Int64 Price { get; set; }
        [DataType(DataType.Upload)]
        public List<EstateImage> EstateImages { get; set; }
        public string EstateLogo { get; set; }
        [Column(TypeName ="smalldatetime")]
        public DateTime RegDate { get; set; }
        public bool Enable { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
        public virtual EstateStatus EstateStatus { get; set; }


    }
}
