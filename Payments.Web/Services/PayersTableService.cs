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
    public class PayersTableService: IPayersTableService
    {
        private readonly HttpClient httpClient;

        public PayersTableService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<PayersTable>> GetPayersTables()
        {
            return await httpClient.GetJsonAsync<PayersTable[]>("api/Payers/GetPayersTables");
        }
        public async Task<PayersTable> GetPayersTable(int id)
        {
            return await httpClient.GetJsonAsync<PayersTable>($"api/Payers/GetPayersTable/{id}");
        }
        public async Task<PayersTable> GetPayerByName(string name)
        {
            return await httpClient.GetJsonAsync<PayersTable>($"/api/Payers/GetPayerByName/{name}");
        }
    }
}
