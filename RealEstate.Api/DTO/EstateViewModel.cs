using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Api.DTO
{
   public class EstateViewModel
    {
        public int Id { get; set; }
        public string EstateStatusName { get; set; }
        public string Title { get; set; }
        public Int64 Price { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public int Baths { get; set; }
        public int Beds { get; set; }
        public int Garages { get; set; }
        public string EstateLogo { get; set; }
    }
}
