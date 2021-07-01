using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IPaymentScheduleService
    {

        Task<IEnumerable<PaymentSchedule>> GetPaymentSchedulees();
        Task<PaymentSchedule> AddPaymentSchedule(PaymentSchedule status);
        Task<PaymentSchedule> GetPaymentSchedule(int id);
        Task<PaymentSchedule> UpdatePaymentSchedule(PaymentSchedule status);
        Task DeletePaymentSchedule(int id);
        Task<IEnumerable<PaymentSchedule>> GetPaymentSchedulesBySolutionId(int id);
        Task<PaymentSchedule> IsPaid(int id);
    }
}
