using AutoMapper;
using RealEstate.Api.DTO;
using RealEstate.Domain.Estate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Domain.Dto
{
   public class MappingEntity:Profile
    {
        public MappingEntity()
        {
            CreateMap<EstateViewModel, Estates>().ReverseMap();
        }
    }
}
