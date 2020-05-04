using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Domain.Dto
{
  public class RequestEstateViewModel
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Username { get; set; }
        public string EstateName { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }
        public bool Enabled { get; set; }

    }
}
