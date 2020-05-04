//using Microsoft.Extensions.Options;
//using RealEstate.Api.DTO;
//using RealEstate.Api.Helper;
//using RealEstate.Api.Interface;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace RealEstate.Api.Service
//{
//    public class UserService : IUserService
//    {
//        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
//        private List<LoginModel> _users = new List<LoginModel>
//        {
//            new LoginModel {  Username = "test", Password = "test" }
//        };

//        private readonly AppSettings _appSettings;
//        public UserService(IOptions<AppSettings> appSettings)
//        {
//            _appSettings = appSettings.Value;
//        }
//        public LoginModel Authenticate(string username, string password)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<LoginModel> GetAll()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
