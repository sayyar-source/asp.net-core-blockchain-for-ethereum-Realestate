using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Api.DTO;
using RealEstate.DataLayer;
using RealEstate.Domain;
using RealEstate.Domain.Dto;
using RealEstate.Services.Repositories;
using RealEstate.UI.Models;

namespace RealEstate.UI.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        IUserRepository _userRepository;
        public AuthenticateController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login(LoginModel model)
        {
           
            //var token = await _userRepository.Login(model);

            //if (token != null)
            //{
            //    //HttpContext.Session.SetString("JWToken", token);
            //    // return Ok(token);
            //    // return Redirect("api/Account/Index");
            //     return RedirectToAction("Index", "Account", "api");
           
            //}
            return View();



        }
        //[HttpPost("Register")]
        //public async Task<IActionResult> RegisterUser([FromBody] UserViewModel model)
        //{
        //  var result= await _userRepository.CreateUser(model);
        //    return new JsonResult(result);
        //}
        //[HttpGet]
        //public async Task<IActionResult> Logout()
        //{

        //    return Redirect("/Account/Login");

        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
