using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.DTO;
using RealEstate.Domain;
using RealEstate.Domain.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RealEstate.Services.Repositories
{
   public interface IUserRepository:IRepository<UserViewModel>
    {
        Task<CreateUserResponse> CreateUser(UserViewModel model);
        Task<UserViewModel> FindUserByName(string userName);
        Task<bool> CheckPassword(UserViewModel user, string password);
        Task<LoginModel> Login(LoginModel model);
       // Task<JsonResult> Logout();
    }
}
