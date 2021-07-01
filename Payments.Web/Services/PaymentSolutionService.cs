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
    public class PaymentSolutionService : IPaymentSolutionService
    {
        private readonly HttpClient httpClient;

        public PaymentSolutionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<PaymentSolution> AddPaymentSolution(PaymentSolution status)
        {
            return await httpClient.PostJsonAsync<PaymentSolution>($"api/PaymentSolution/AddPaymentSolution/{status}",status);
        }

        public async Task<PaymentSolution> UpdatePaymentSolution(PaymentSolution status)
        {
            return await httpClient.PostJsonAsync<PaymentSolution>($"api/PaymentSolution/UpdatePaymentSolution/{status}",status);
        }

        public async Task<PaymentSolution> GetPaymentSolution(int id)
        {
            return await httpClient.GetJsonAsync<PaymentSolution>($"/api/PaymentSolution/GetPaymentSolution/{id}");
        }

        public async Task<IEnumerable<PaymentSolution>> GetPaymentSolutiones()
        {
            return await httpClient.GetJsonAsync<PaymentSolution[]>($"/api/PaymentSolution/GetPaymentSolutiones");
        }

        public async Task DeletePaymentSolution(int id)
        {
            await httpClient.DeleteAsync($"/api/PaymentSolution/DeletePaymentSolution/{id}");
        }
    }
}
