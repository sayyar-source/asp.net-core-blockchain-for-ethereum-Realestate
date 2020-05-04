using Nethereum.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Repositories
{
   public interface IRealEstateService
    {
        Task<int> Getbalance(string address);
        Task<string> AddAcount(string Password);
        Task<Contract> GetContract(string name);
        Task<bool> AddEstateContract(uint ecCode, string addressBuyer, string addressSeller, uint amount);
        Task<string> getOwner(uint ecCode);
        Task<bool> Accept(uint ecCode);
        void SetAccount(string accountAddress, string accountPassword);
    }
}
