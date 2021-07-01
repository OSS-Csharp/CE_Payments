using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IPaymentSolutionService
    {

        Task<IEnumerable<PaymentSolution>> GetPaymentSolutiones();
        Task<PaymentSolution> AddPaymentSolution(PaymentSolution status);
        Task<PaymentSolution> GetPaymentSolution(int id);
        Task<PaymentSolution> UpdatePaymentSolution(PaymentSolution status);
        Task DeletePaymentSolution(int id);
    }
}
