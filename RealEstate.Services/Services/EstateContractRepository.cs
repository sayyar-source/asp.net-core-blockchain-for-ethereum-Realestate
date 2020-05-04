using Microsoft.EntityFrameworkCore;
using RealEstate.DataLayer.Context;
using RealEstate.Domain.Dto;
using RealEstate.Domain.Estate;
using RealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Services
{
    public class EstateContractRepository : IEstateContractRepository
    {
        RealEstateDbContext _db;
        public EstateContractRepository(RealEstateDbContext db)
        {
            _db = db;
        }

        public List<EstateContract> GetAllContracts()
        {
            return _db.EstateContracts.Where(c=>c.Enable==true).ToList();
        }

        public ContractEstateViewModel GetContractDetiles(int ContractId)
        {
            var item = _db.EstateContracts.Where(r => r.Id == ContractId)
                .Include(e => e.Estates)
                .Include(b => b.BuyerUser)
                .Include(o=>o.OwnerUser)
                .Include(s=>s.SellerUser)
                .Select(c => new ContractEstateViewModel 
                { 
                 ContractId=c.Id,
                 CreateDate=c.Created,
                 OwnerName=c.OwnerUser.FirstName,
                 OwnerLastname=c.OwnerUser.LastName,
                 OwnerPhone=c.OwnerUser.PhoneNumber,
                 SelerName=c.SellerUser.UserName,
                 SelerLastname=c.SellerUser.LastName,
                 SelerPhone=c.SellerUser.PhoneNumber,
                 BuyerName=c.BuyerUser.UserName,
                 BuyerLastname=c.BuyerUser.LastName,
                 BuyerPhone=c.BuyerUser.PhoneNumber,
                 EstateTitle=c.Estates.Title,
                 BuyerOk=c.BuyerOK,
                 SelerOk=c.SellerOK,
                 BuyerOkTime=c.BuyerOKTime,
                 SelerOkTime=c.SellerOKTime,
                 Amount=c.Amount,
                 Note=c.Note,
                 LogoURL=c.Estates.EstateLogo
                })
                .FirstOrDefault();
        
            return item;
        }

        public EstateContract GetEstateContract(int estateContractId)
        {
            return  _db.EstateContracts.FirstOrDefault(es => es.Id == estateContractId); 
                
        }

        public List<EstateContract> GetEstateContracts(int estateId)
        {
            return _db.EstateContracts.Where(es => es.EstateId == estateId).ToList();
        }

        public void IsertEstateContract(EstateContract estateContract)
        {
            _db.EstateContracts.Add(estateContract);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
