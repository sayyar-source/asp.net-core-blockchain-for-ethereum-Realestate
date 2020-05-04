using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstate.Domain.Admin
{
  public class State
    {
        public State()
        {

        }
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
