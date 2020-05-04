using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstate.Domain.Admin
{
   public class City
    {
        public City()
        {

        }
        [Key]
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
       public virtual State State { get; set; }
    }
}
