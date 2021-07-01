using Microsoft.AspNetCore.Components;
using Payments.Model.Entities;
using Payments.Model.Models;
using Payments.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Payments.Web.Services
{
    public class PaymentInformationService : IPaymentInformationService
    {
        private readonly HttpClient httpClient;

        public PaymentInformationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<PaymentInformation> AddPaymentInformation(PaymentInformation info)
        {
            return await httpClient.PostJsonAsync<PaymentInformation>($"/api/PaymentInformation/AddPaymentInformation/{info}",info);
        }

        public async Task<PaymentInformation> UpdatePaymentInformation(PaymentInformation info)
        {
            return await httpClient.PostJsonAsync<PaymentInformation>($"api/PaymentInformation/UpdatePaymentInformation/{info}",info);
        }

        public async Task<PaymentInformation> GetPaymentInformation(int id)
        {
            return await httpClient.GetJsonAsync<PaymentInformation>($"/api/PaymentInformation/GetPaymentInformation/{id}");
        }

        public async Task<IEnumerable<PaymentInformation>> GetPaymentInformationes()
        {
            return await httpClient.GetJsonAsync<PaymentInformation[]>($"/api/PaymentInformation/GetPaymentInformationes");
        }

        public async Task DeletePaymentInformation(int id)
        {
            await httpClient.DeleteAsync($"/api/PaymentInformation/DeletePaymentInformation/{id}");
        }
    }
}
