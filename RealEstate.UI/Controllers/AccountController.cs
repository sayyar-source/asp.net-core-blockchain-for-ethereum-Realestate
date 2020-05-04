using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstate.Api.DTO;
using RealEstate.DataLayer;
using RealEstate.Domain;
using RealEstate.Services.Repositories;

namespace RealEstate.UI.Controllers
{
    [Authorize]
    // [Route("api/[controller]")]
    [Route("[controller]")]
    public class AccountController : Controller
    {

        IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly IRealEstateService _realEstateService;
        public AccountController(ILogger<AccountController> logger,
            IRealEstateService realEstateService,
            IUserRepository userRepository)
        {
            _logger = logger;
            _realEstateService = realEstateService;
            _userRepository = userRepository;

        }

        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // If the user is already authenticated we do not need to display the login page, so we redirect to the landing page. 
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            string returnUrl = "~/Home/Index";
            var user = await _userRepository.Login(model);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,user.JobType),
                    new Claim(ClaimTypes.GivenName,user.FirstName+" "+user.LastName),
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                  
                    new Claim(ClaimTypes.PrimarySid,user.EthAccountAddress)
                };
                var userIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToLocal(returnUrl);
            }
            return View();
        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/Account/Login");
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Account");
        }

        [HttpGet("Index")]
        public IActionResult Index()

        {
            return View();
        }
        [HttpGet("RegisterUser")]
        [AllowAnonymous]
        public IActionResult RegisterUser()
        {
            
                    ViewBag.success = TempData["success"];
                    ViewBag.message = TempData["message"];
              
            

            return View();
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var result = await _userRepository.CreateUser(model);
          
      
                TempData["success"] = result.Success;
                TempData["message"] = result.Errors;
            return RedirectToAction("RegisterUser");
            
        }
    }
}