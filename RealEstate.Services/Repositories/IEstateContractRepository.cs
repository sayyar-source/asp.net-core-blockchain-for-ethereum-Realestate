using RealEstate.Domain.Dto;
using RealEstate.Domain.Estate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Repositories
{
   public interface IEstateContractRepository
    {
        List<EstateContract> GetEstateContracts(int estateId);
        EstateContract GetEstateContract(int estateContractId);
        void IsertEstateContract(EstateContract estateContract);
        List<EstateContract> GetAllContracts();
        ContractEstateViewModel GetContractDetiles(int ContractId);
        void Save();
    }
}
