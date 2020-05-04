

using Microsoft.EntityFrameworkCore;
using RealEstate.DataLayer.Context;
using RealEstate.Domain.Admin;
using RealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstate.Services.Services
{
    public class CityRepository : ICityRepository
    {
        private readonly RealEstateDbContext _db;
        public CityRepository(RealEstateDbContext db)
        {
            _db = db;
        }
        public bool CityExists(int id)
        {
            return _db.Cities.Any(c => c.CityId == id);
        }
        public void DeleteCity(int cityid)
        {
            var city = GetCityById(cityid);
            _db.Cities.Remove(city);
        }

        public List<City> GetAllCity()
        {
            return _db.Cities.Include(c => c.State).ToList();
        }

        public City GetCityById(int cityid)
        {
            return _db.Cities.Find(cityid);
        }

        public void InsertCity(City city)
        {
            _db.Cities.Add(city);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateCity(City city)
        {
            _db.Cities.Update(city);
            Save();
        }
    }
}
