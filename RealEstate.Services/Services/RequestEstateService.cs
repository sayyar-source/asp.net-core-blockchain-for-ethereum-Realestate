using Microsoft.EntityFrameworkCore;
using RealEstate.DataLayer.Context;
using RealEstate.Domain.Dto;
using RealEstate.Domain.Estate;
using RealEstate.Domain.User;
using RealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Services
{
    public class RequestEstateService : IRequestEstateRepository
    {
        private readonly RealEstateDbContext _db;
        public RequestEstateService(RealEstateDbContext db)
        {
            _db = db;
        }
        public async Task<RequestEstate> Add(RequestEstate entity)
        {
            RequestEstate request = new RequestEstate
            {
                Enable = true,
                EstateId=entity.EstateId,
                Modified=DateTime.Now,
                Created=DateTime.Now,
                Note=entity.Note,
                SaveUserId=entity.SaveUserId,
                Subject=entity.Subject
                
            };
           await _db.AddAsync(request);
           await _db.SaveChangesAsync();
           return entity;
        }

        public async Task Delete(RequestEstate entity)
        {
            _db.RequestEstates.Remove(entity);
            await _db.SaveChangesAsync();

        }

        public async Task<RequestEstate> GetById(int id)
        {
            var result =await  _db.RequestEstates.Where(r => r.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<RequestEstate>> ListAll()
        {

           

            return null;
        }

        public async Task Update(RequestEstate entity)
        {
            _db.RequestEstates.Update(entity);
            await _db.SaveChangesAsync();
        }
       public async Task<List<RequestEstateViewModel>> GetAllRequest()
        {
            var result = await _db.RequestEstates
                .Include(e => e.Estate)
                .Include(u => u.ApplicationUser)
                .Select(r => new RequestEstateViewModel
                {
                    Id = r.Id,
                    CreateDate = r.Created,
                    EstateName = r.Estate.Title,
                    Note = r.Note,
                    Subject = r.Subject,
                    Username = r.ApplicationUser.UserName,
                    Enabled=r.Enable
                })
                .ToListAsync();

            return result;
        }

        public async Task<ApplicationUser> GetRequestDeties(string username)
        {
            var result =await _db.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();
            return result;
        }
    }
}
