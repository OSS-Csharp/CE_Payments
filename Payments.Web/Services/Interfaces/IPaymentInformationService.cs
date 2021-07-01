using Payments.Model.Entities;
using Payments.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IPaymentInformationService
    {

        Task<IEnumerable<PaymentInformation>> GetPaymentInformationes();
        Task<PaymentInformation> AddPaymentInformation(PaymentInformation status);
        Task<PaymentInformation> GetPaymentInformation(int id);
        Task<PaymentInformation> UpdatePaymentInformation(PaymentInformation status);
        Task DeletePaymentInformation(int id);
    }
}
