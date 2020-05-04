

using RealEstate.Domain.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Services.Repositories
{
    
   public interface ICityRepository
    {

        List<City> GetAllCity();
        City GetCityById(int cityid);
        void InsertCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int cityid);
        bool CityExists(int id);
        void Save();
    }
}
