
using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IFinalBillService
    {
        Task<IEnumerable<FinalBill>> GetFinalBIlls();
        Task<FinalBill> GetFinalBill(int Id);
        Task<FinalBill> AddFinalBill(FinalBill bill);
        Task<FinalBill> UpdateFinalBill(FinalBill bill);
        Task<IEnumerable<FinalBill>> GetAllByPayer(int id);
        Task<IEnumerable<FinalBill>> GetAllByReceiver(int id);
        
            Task<FinalBill> GetFinalBillByPaymentSolution(int Id);
    }
}
