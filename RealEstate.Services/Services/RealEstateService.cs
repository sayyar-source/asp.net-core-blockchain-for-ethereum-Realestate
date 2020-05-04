using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;

using Nethereum.RPC.Eth.DTOs;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using RealEstate.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace RealEstate.Services.Services
{
    public class RealEstateService : IRealEstateService
    {
       private Web3 web3 = new Web3("HTTP://127.0.0.1:7545");
        private string address = "0x3f613Dcc61Ff0e3F5dAC2a6Cb48dc3C2BA31B12E";
        private string _accountAddress = "";
        private string _accountPassword = "";
        private string _contractAddress = "0x495202205EFD9949237d226CAbcE06A55d2aaDFb";
        private string _contractABI = @"[{'constant':false,'inputs':[{'internalType':'uint256','name':'ecCode','type':'uint256'}],'name':'accept','outputs':[{'internalType':'bool','name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'internalType':'uint256','name':'ecCode','type':'uint256'},{'internalType':'address','name':'buyer','type':'address'},{'internalType':'address','name':'seller','type':'address'},{'internalType':'uint256','name':'amount','type':'uint256'}],'name':'addEstateContract','outputs':[{'internalType':'bool','name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'constant':false,'inputs':[{'internalType':'address','name':'sender','type':'address'},{'internalType':'address','name':'receiver','type':'address'},{'internalType':'uint256','name':'transferAmount','type':'uint256'}],'name':'transferFrom','outputs':[{'internalType':'bool','name':'','type':'bool'}],'payable':false,'stateMutability':'nonpayable','type':'function'},{'inputs':[],'payable':true,'stateMutability':'payable','type':'constructor'},{'constant':true,'inputs':[{'internalType':'address','name':'accountToCheck','type':'address'}],'name':'customerExist','outputs':[{'internalType':'bool','name':'','type':'bool'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'internalType':'uint256','name':'','type':'uint256'}],'name':'EsContractStrsCodes','outputs':[{'internalType':'uint256','name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'internalType':'address','name':'tokenOwner','type':'address'}],'name':'getBalance','outputs':[{'internalType':'uint256','name':'','type':'uint256'}],'payable':false,'stateMutability':'view','type':'function'},{'constant':true,'inputs':[{'internalType':'uint256','name':'ecCode','type':'uint256'}],'name':'getOwner','outputs':[{'internalType':'address','name':'owner','type':'address'}],'payable':false,'stateMutability':'view','type':'function'}]";
        private string _contractName = "RealEstateToken";
        public async Task<bool> Accept(uint ecCode)
        {
            var contract = await GetContract(_contractName);
            var method = contract.GetFunction("accept");
            HexBigInteger gas = new HexBigInteger(new HexBigInteger(900000));
            HexBigInteger value = new HexBigInteger(new HexBigInteger(0));
            var transactionHash =await method.SendTransactionAsync(_accountAddress, gas, null, ecCode);
            var receipt =await GetReceiptAsync(transactionHash);
            //var result=method.CallDeserializingToObjectAsync<OutputDocument>(_accountAddress, new HexBigInteger(3000000)
            //    , new HexBigInteger(0), ecCode);

            return true;
        }

        public async Task<TransactionReceipt> GetReceiptAsync(string transactionHash)
        {
            var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);
            while(receipt==null)
            {
                Thread.Sleep(1000);
                receipt =await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);

            }
            return receipt;
        }
        public async Task<string> AddAcount(string Password)
        {
            var account =await web3.Personal.NewAccount.SendRequestAsync(Password);
            return account.ToString();
        }
        public async Task<string> Transfer(string recipient, BigInteger transferwei)
        {

            _accountAddress = address;
            _accountPassword = "Ali@123";
            var result = await web3.Personal.UnlockAccount.SendRequestAsync(_accountAddress, _accountPassword, 60);
            if (result)
            {
                string privateKey = "76eb2bb5474b8fa197103402cf565154816c93040dcf87402b1c7b45f1366572";
                Account ac1 = new Account(privateKey);
                string ac2 = recipient;

                var receipt = SendEther(ac1, ac2, web3, transferwei).Result;
                return receipt.TransactionHash;

            }
            return null;


        }
        private static async Task<TransactionReceipt> SendEther(Account account, string recipient, Web3 web3, BigInteger transferwei)
        {
            var transactionPolling = web3.TransactionManager.TransactionReceiptService;
            HexBigInteger nonce = web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(account.Address).Result;

            return await transactionPolling.SendRequestAndWaitForReceiptAsync(() =>
            {
                var transactionInput = new TransactionInput
                {
                    From = account.Address,
                    //Gas = new HexBigInteger(25000),
                    GasPrice = new HexBigInteger(10 ^ 10),
                    To = recipient,
                    Value = new HexBigInteger(transferwei),
                    Nonce = nonce

                };
                var txSigned = new Nethereum.Signer.TransactionSigner();
                var signedTx = txSigned.SignTransaction(account.PrivateKey, transactionInput.To, transactionInput.Value, transactionInput.Nonce);
                var transaction = new Nethereum.RPC.Eth.Transactions.EthSendRawTransaction(web3.Client);
                return transaction.SendRequestAsync(signedTx);
            });
        }
        public async Task<bool> AddEstateContract(uint ecCode, string addressBuyer, string addressSeller, uint amount)
        {
            var contract =await GetContract(_contractName);
            var method = contract.GetFunction("addEstateContract");
            var estimate = await method.EstimateGasAsync(ecCode, addressBuyer, addressSeller, amount);
            var estimateGas = estimate.Value;
            // Transfer
          //  var trans = await Transfer(address, Web3.Convert.ToWei(new HexBigInteger(2) * estimateGas, UnitConversion.EthUnit.Gwei));
            //


            HexBigInteger gas = new HexBigInteger(3000000);
            HexBigInteger value = new HexBigInteger(0);
            var transactionHash = await method.SendTransactionAsync(address, gas,value, ecCode, 
                addressBuyer, addressSeller, amount);

            var gasUsed = GetReceiptAsync(transactionHash).Result.GasUsed.Value;

            var result=await method.CallDeserializingToObjectAsync<OutputDocument>(address, gas,value, ecCode, 
                addressBuyer, addressSeller, amount);
            return result.Result;
        }

        public async Task<int> Getbalance(string address)
        {
            var contract = await GetContract(_contractName);
            var method = contract.GetFunction("getBalance");
            var result = await method.CallAsync<int>(address);
            return result;
        }

        public async Task<Contract> GetContract(string name)
        {
            //var contractaddress = "0x848275ceccf22e78ddd923135b32eb6b224f563f";
            //var password = "Ali@123";
            //SetAccount(contractaddress, password);
            //var result = await web3.Personal.UnlockAccount.SendRequestAsync(_accountAddress, _accountPassword, 60);
            //if (result)
            //{
            Contract contract = web3.Eth.GetContract(_contractABI, _contractAddress);
            
            return contract;
        //}
        //    return null;
        }

        public async Task<string> getOwner(uint ecCode)
        {
            var contract =await GetContract(_contractName);
            var method = contract.GetFunction("getOwner");
            var result = await method.CallAsync<string>(ecCode);
            return result;
        }
        public void SetAccount(string accountAddress, string accountPassword)
        {
         
         
            _accountAddress = accountAddress;
            _accountPassword = accountPassword;
        }
    }
}
