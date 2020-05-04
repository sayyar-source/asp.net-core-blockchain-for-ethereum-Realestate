using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstate.Domain.Estate;
using RealEstate.Services.Repositories;
using RealEstate.UI.Models;

namespace RealEstate.UI.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IEstateRepository _estateRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestEstateRepository _requestEstateRepository;
  
        public HomeController(ILogger<HomeController> logger, IEstateRepository estateRepository, IRequestEstateRepository requestEstateRepository)
        {
            _logger = logger;
            _estateRepository = estateRepository;
            _requestEstateRepository = requestEstateRepository;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.userlogin = true;
                ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
                Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
                var role = claim.Value;
                ViewBag.role = role;
                ViewBag.username = User.Identity.Name;
              

            }
            var model = await _estateRepository.ListAll();
            return View(model.GetRange(0, 3));
        }
        public async Task<IActionResult> Listings()
        {

            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            var model = await _estateRepository.ListAll();
            return View(model);
        }
        public IActionResult About()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            return View();
        }
        public IActionResult Blog()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            return View();
        }
        public IActionResult Contact()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            return View();
        }
        public async Task<IActionResult> Single(int id)
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            ViewBag.username = User.Identity.Name;
            var model = await _estateRepository.GetById(id);
           
            return View(model);
        }
        [HttpPost]
        [Route("{controller}/sendmessage")]
        public IActionResult SendMessage(RequestEstate requestEstate)
        {
          
            _requestEstateRepository.Add(requestEstate);
            return RedirectToAction("Single",new {id= requestEstate.EstateId });
        }


    }
}
