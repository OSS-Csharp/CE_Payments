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
    public class FinalBillService: IFinalBillService
    {
        private readonly HttpClient httpClient;

        public FinalBillService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<FinalBill>> GetFinalBIlls()
        {
            return await httpClient.GetJsonAsync<FinalBill[]>("api/FinalBills/GetFinalBills");
        }
        public async Task<FinalBill> GetFinalBill(int id)
        {
            return await httpClient.GetJsonAsync<FinalBill>($"api/FinalBills/GetFinalBill/{id}");
        }

        public async Task<IEnumerable<FinalBill>> GetAllByPayer(int id)
        {
            return await httpClient.GetJsonAsync<FinalBill[]>($"/api/FinalBills/GetAllByPayer/{id}");
        }

        public async Task<IEnumerable<FinalBill>> GetAllByReceiver(int id)
        {
            return await httpClient.GetJsonAsync<FinalBill[]>($"api/FinalBills/GetAllByReceiver/{id}");
        }

        public async Task<FinalBill> AddFinalBill(FinalBill bill)
        {
            return await httpClient.PostJsonAsync<FinalBill>($"/api/FinalBills/AddFinalBill/{bill}",bill);
        }
        
        public async Task<FinalBill> GetFinalBillByPaymentSolution(int id)
        {
            return await httpClient.GetJsonAsync<FinalBill>($"/api/FinalBills/GetFinalBillByPaymentSolution/{id}");
        }

        public async Task<FinalBill> UpdateFinalBill(FinalBill finalbill)
        {
            return await httpClient.PostJsonAsync<FinalBill>($"/api/FinalBills/UpdateFinalBill/{finalbill}", finalbill);
        }
    }
}
