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
    public class PaymentScheduleService : IPaymentScheduleService
    {
        private readonly HttpClient httpClient;

        public PaymentScheduleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<PaymentSchedule> AddPaymentSchedule(PaymentSchedule status)
        {
            return await httpClient.PostJsonAsync<PaymentSchedule>($"api/PaymentSchedule/AddPaymentSchedule/{status}",status);
        }

        public async Task<PaymentSchedule> UpdatePaymentSchedule(PaymentSchedule status)
        {
            return await httpClient.PostJsonAsync<PaymentSchedule>($"api/PaymentSchedule/UpdatePaymentSchedule/{status}",status);
        }

        public async Task<PaymentSchedule> GetPaymentSchedule(int id)
        {
            return await httpClient.GetJsonAsync<PaymentSchedule>($"/api/PaymentSchedule/GetPaymentSchedule/{id}");
        }

        public async Task<IEnumerable<PaymentSchedule>> GetPaymentSchedulees()
        {
            return await httpClient.GetJsonAsync<PaymentSchedule[]>($"/api/PaymentSchedule/GetPaymentSchedulees");
        }

        public async Task DeletePaymentSchedule(int id)
        {
            await httpClient.DeleteAsync($"/api/PaymentSchedule/DeletePaymentSchedule/{id}");
        }

        public async Task<IEnumerable<PaymentSchedule>> GetPaymentSchedulesBySolutionId(int id)
        {
            return await httpClient.GetJsonAsync<PaymentSchedule[]>($"/api/PaymentSchedule/GetPaymentSchedulesBySolutionId/{id}");
        }

        public async Task<PaymentSchedule> IsPaid(int id)
        {
            return await httpClient.PostJsonAsync<PaymentSchedule>($"/api/PaymentSchedule/IsPaid/{id}",id);
        }
    }
}
