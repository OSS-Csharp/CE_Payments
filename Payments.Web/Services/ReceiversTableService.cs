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
    public class ReceiversTableService: IReceiversTableService
    {
        private readonly HttpClient httpClient;

        public ReceiversTableService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ReceiversTable>> GetReceiversTables()
        {
            return await httpClient.GetJsonAsync<ReceiversTable[]>("/api/Receivers/GetReceivers");
        }
        public async Task<ReceiversTable> GetReceiversTable(int id)
        {
            return await httpClient.GetJsonAsync<ReceiversTable>($"/api/Receivers/GetReceiver/{id}");
        }
        public async Task<ReceiversTable> GetReceiverByName(string name)
        {
            return await httpClient.GetJsonAsync<ReceiversTable>($"/api/Receivers/GetPayerByName/{name}");
        }
    }
}
