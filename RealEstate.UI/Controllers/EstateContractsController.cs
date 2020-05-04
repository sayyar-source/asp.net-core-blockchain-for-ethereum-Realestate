using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.DataLayer;
using RealEstate.Domain.Estate;
using RealEstate.Domain.User;
using RealEstate.Services.Repositories;

namespace RealEstate.UI.Controllers
{
    [Authorize]
    public class EstateContractsController : Controller
    {
        private readonly IEstateContractRepository _estateContractRepository;
        private readonly IRealEstateService _realEstateService;
        private readonly IRequestEstateRepository _requestEstateRepository;
        private readonly IEstateRepository _estateRepository;
        private readonly UserManager<ApplicationUser> _userManager;
     
   
        public EstateContractsController(IEstateContractRepository estateContractRepository, IEstateRepository estateRepository, IRealEstateService realEstateService, IRequestEstateRepository requestEstateRepository, UserManager<ApplicationUser> userManager)
        {
           
            _estateContractRepository = estateContractRepository;
            _realEstateService = realEstateService;
            _requestEstateRepository = requestEstateRepository;
            _estateRepository = estateRepository;
            _userManager = userManager;
           
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.userlogin = true;
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            ViewData["EstateId"] = id;
            var us = _userManager.FindByNameAsync(User.Identity.Name).Result.Email;
            ViewData["Balance"] =await _realEstateService.Getbalance(_userManager.FindByNameAsync(User.Identity.Name).Result.EthAccountAddress);
            var estateContracts = _estateContractRepository.GetEstateContracts(id);
            return View(estateContracts);
        }
        public async Task<IActionResult> Detiles(int? id)
        {
            ViewBag.userlogin = true;
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            if (id==null)
            {
                return NotFound();
            }
            var estateContract = _estateContractRepository.GetEstateContract(id.Value);
            if(estateContract==null)
            {
                return NotFound();
            }
            return View(estateContract);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            ViewBag.userlogin = true;
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            ViewData["EstateId"] = id;
            ViewData["MyUser"] = new SelectList(_userManager.Users, "Id", "Email");
           
            ViewData["Estats"] = new SelectList(await _estateRepository.ListAll(), "Id", "Title");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EstateContract estateContract) 
        {
          
            var userId = User.Identities.First().Claims.Where(r => r.Type == ClaimTypes.NameIdentifier).Select(t => t.Value).FirstOrDefault();
            var role = User.Identities.First().Claims.Where(c=>c.Type==ClaimTypes.Role).Select(v=>v.Value).FirstOrDefault();
            ViewBag.role = role;
            
            if (ModelState.IsValid)
            {
                estateContract.BuyerOK = false;
                estateContract.SellerOK = false;
                estateContract.Modified = DateTime.Now;
                estateContract.Created = DateTime.Now;
                estateContract.OwnerUserId = userId;
                estateContract.Enable = true;
                _estateContractRepository.IsertEstateContract(estateContract);

              var success =  await _realEstateService.AddEstateContract(Convert.ToUInt32(estateContract.Id),
                    _userManager.FindByIdAsync(estateContract.BuyerUserId).Result.EthAccountAddress,
                    _userManager.FindByIdAsync(estateContract.SellerUserId).Result.EthAccountAddress,
                   Convert.ToUInt16(estateContract.Amount));
                ViewData["success"] = success;
                return View();
               // return RedirectToAction("Index", new { id = estateContract.EstateId });
            }
            ViewData["EstateId"] = estateContract.EstateId;
            return View(estateContract);

        }
        public IActionResult ContractsList()
        {
            ViewBag.userlogin = true;
            var conctacts = _estateContractRepository.GetAllContracts();
            var userid = User.Identities.First().Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(s => s.Value).First();
            var role = User.Identities.First().Claims.Where(c => c.Type == ClaimTypes.Role).Select(s => s.Value).FirstOrDefault();
            ViewBag.role = role;
            if (role == "Buyer")
            {
                conctacts = conctacts.Where(c => c.BuyerUserId == userid ).ToList();
            }
            if (role == "Seller")
            {
                conctacts = conctacts.Where(c => c.SellerUserId == userid ).ToList();
            }
            return View(conctacts);
        }
        [HttpGet]
        public IActionResult ContractDetiles(int EstateId)
        {
            ViewBag.userlogin = true;
            var model = _estateContractRepository.GetContractDetiles(EstateId);
            return View(model);
        }
        [HttpGet]
        public IActionResult AcceptContract(int contractId)
        {
            var role = User.Identities.First().Claims.Where(c => c.Type == ClaimTypes.Role).Select(s => s.Value).FirstOrDefault();
            ViewBag.role = role;
            ViewBag.userlogin = true;
            var model = _estateContractRepository.GetContractDetiles(contractId);
            return View(model);
        }
        
        public async Task<IActionResult> Accept(int id)
        {

            ViewBag.userlogin = true;
            var estateContract = _estateContractRepository.GetEstateContract(id);
            if(User.FindFirst(ClaimTypes.NameIdentifier).Value==estateContract.BuyerUserId)
            {
                estateContract.BuyerOK = true;
                estateContract.BuyerOKTime = DateTime.Now;
            }
            if(User.FindFirst(ClaimTypes.NameIdentifier).Value==estateContract.SellerUserId)
            {
                estateContract.SellerOK = true;
                estateContract.SellerOKTime = DateTime.Now;
            }
            string account = User.Identities.First().Claims.Where(c => c.Type == ClaimTypes.PrimarySid).Select(s => s.Value).FirstOrDefault();
           // _realEstateService.SetAccount(account, "Ali@123");
            await _realEstateService.Accept(Convert.ToUInt32(estateContract.Id));
            _estateContractRepository.Save();
            return RedirectToAction("AcceptContract", new { contractId = estateContract.Id });
        }
        public async Task<IActionResult> RequestList()
        {
            ViewBag.userlogin = true;
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            var result =await _requestEstateRepository.GetAllRequest();
            var result2 = result.Where(g => g.Enabled == true).ToList();
            
            TempData["Subject"] = result2.FirstOrDefault().Subject;
            TempData["Note"] = result2.FirstOrDefault().Note;
            return  View(result2);
        }
        [HttpGet]
        public async Task<IActionResult> RequestDetiles(string username)
        {
          
            ViewBag.userlogin = true;
            ViewBag.Subject = TempData["Subject"];
            ViewBag.Note = TempData["Note"];
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Role);
            var role = claim.Value;
            ViewBag.role = role;
            var model =await _requestEstateRepository.GetRequestDeties(username);
            return View(model);
        }
        

    }
}