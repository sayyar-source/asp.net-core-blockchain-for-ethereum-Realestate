using RealEstate.Domain.Dto;
using RealEstate.Domain.Estate;
using RealEstate.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Repositories
{
    public interface IRequestEstateRepository : IRepository<RequestEstate>
    {
        Task<List<RequestEstateViewModel>> GetAllRequest();
        Task<ApplicationUser> GetRequestDeties(string username);
    }
}
