using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.Web.Services
{
    public class ContractService: IContractService
    {
        private readonly HttpClient httpClient;

        public ContractService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
                return await httpClient.GetJsonAsync<Contract[]>("api/Contracts/GetContracts");
        }
        public async Task<Contract> GetContract(int id)
        {
            return await httpClient.GetJsonAsync<Contract>($"api/Contracts/GetContract/{id}");


        }
       
        public async Task<IEnumerable<Contract>> GetContractsByPayer(string name)
        {
            return await httpClient.GetJsonAsync<Contract[]>($"/api/Contracts/GetContractsByPayer/{name}");
        }

        public async Task<Contract> UpdateContractActivation(Contract contract)
        {
            return await httpClient.PostJsonAsync<Contract>($"/api/Contracts/UpdateContractActivation/{contract}",contract);
        }
    }
}
