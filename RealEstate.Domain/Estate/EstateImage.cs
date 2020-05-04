using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstate.Domain.Estate
{
  public  class EstateImage
    {
        public EstateImage()
        {

        }
        [Key]
        public int EstateImageId { get; set; }
        public string EstateImageName { get; set; }
    }
}
