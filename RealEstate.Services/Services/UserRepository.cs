using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RealEstate.Api.DTO;
using RealEstate.DataLayer;
using RealEstate.DataLayer.Context;
using RealEstate.Domain;
using RealEstate.Domain.Dto;
using RealEstate.Domain.User;
using RealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RealEstate.Services.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IRealEstateService _realEstateService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser>  _signInManager;
        private readonly IMapper _mapper;
        private readonly RealEstateDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, RealEstateDbContext appDbContext, IRealEstateService realEstateService, IConfiguration configuration)//:base(RealEstateDbContext)
        {
            _userManager = userManager;
           _signInManager = signInManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _realEstateService = realEstateService;
            _configuration = configuration;
        }
        public Task<UserViewModel> Add(UserViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckPassword(UserViewModel user, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponse> CreateUser(UserViewModel model)
        {
            string ethAccount =await _realEstateService.AddAcount(model.Password);

            var appUser = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email=model.Email,
                UserName=model.UserName,
                PhoneNumber=model.PhoneNumber,
                JobType=model.JobType,
                EthAccountAddress=ethAccount
            };
            _realEstateService.SetAccount(ethAccount, model.Password);
            var identityResult = await _userManager.CreateAsync(appUser, model.Password);
            if (!identityResult.Succeeded) return new CreateUserResponse(appUser.Id, false, identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
            // _appDbContext.Users.Add(appUser);
            // await _appDbContext.SaveChangesAsync();
            return new CreateUserResponse(appUser.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
           
        }

        public Task Delete(UserViewModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> FindUserByName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserViewModel>> ListAll()
        {
            throw new NotImplementedException();
        }

        public async Task<LoginModel> Login(LoginModel model)
        {
            var accountAddress= _signInManager.UserManager.FindByNameAsync(model.Username).Result.EthAccountAddress;
            _realEstateService.SetAccount(accountAddress, model.Password);

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                LoginModel loginModel = new LoginModel() {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName=user.LastName,
                    Email=user.Email,
                    JobType=user.JobType,
                    EthAccountAddress=user.EthAccountAddress
                };
               
                return loginModel;
            }
            return null  ;
                    
               
            }
       
   

        public Task Update(UserViewModel entity)
        {
            throw new NotImplementedException();
        }
       
    }

       
    
}
