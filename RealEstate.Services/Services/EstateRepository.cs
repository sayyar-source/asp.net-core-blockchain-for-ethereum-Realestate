
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Api.DTO;
using RealEstate.DataLayer.Context;
using RealEstate.Domain.Estate;
using RealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Services
{
    public class EstateRepository : IEstateRepository
    {
        RealEstateDbContext _db;
        IMapper _mapper;
        public EstateRepository(RealEstateDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public Task<Estates> Add(Estates entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Estates entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Estates> GetById(int id)
        {
            var estste =await _db.Estates.Where(s => s.Id == id).FirstOrDefaultAsync();
            return estste;
        }

        public async Task<List<Estates>> ListAll()
        {
            var estate = await _db.Estates.ToListAsync();
           // var esv = _mapper.Map<EstateViewModel>(estate);
            return estate;
               
        }

       

        public Task Update(Estates entity)
        {
            throw new NotImplementedException();
        }
    }
}
