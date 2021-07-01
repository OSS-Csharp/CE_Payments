
using Payments.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payments.Model.Entities;

namespace Payments.Domain.Repository
{
    public class FinalBillRepository : IFinallBillRepository
    {

        private readonly AppDbContext appDbContext;

        public FinalBillRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<FinalBill>> GetFinalBills()
        {
           //var a = appDbContext.FinalBills.ToListAsync();

            return await appDbContext.FinalBills.Include(e => e.Payer).Include(e => e.Receiver).Include(e => e.Status).ToListAsync();
        }
        public async Task<FinalBill> GetFinalBill(int FinalBillId)
        {
            return await appDbContext.FinalBills.Include(e => e.Payer).Include(e => e.Receiver).Include(e => e.Status).FirstOrDefaultAsync(e => e.IdFinalBill == FinalBillId); ;
        }


        public async Task<FinalBill> AddFinalBill(FinalBill FinalBill)
        {
            //FinalBill.IdFinalBill = null;
            var result = await appDbContext.FinalBills.AddAsync(FinalBill);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<FinalBill> UpdateFinalBill(FinalBill FinalBill)
        {
            var result = await appDbContext.FinalBills.FirstOrDefaultAsync(e => e.IdFinalBill == FinalBill.IdFinalBill);
            if (result != null)
            {
                result.StatusId = FinalBill.StatusId;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<FinalBill> DeleteFinalBill(int FinalBillId)
        {
            var result = await appDbContext.FinalBills.FirstOrDefaultAsync(e => e.IdFinalBill == FinalBillId);
            if (result != null)
            {
                appDbContext.FinalBills.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<FinalBill>> GetAllByPayer(int payerId)
        {
            return await appDbContext.FinalBills.Include(e => e.Payer).Include(e => e.Receiver).Include(e => e.Status).Where(p=>p.PayerId ==payerId).ToListAsync();
        }

        public async Task<IEnumerable<FinalBill>> GetAllByReceiver(int receiverId)
        {
            return await appDbContext.FinalBills.Include(e => e.Payer).Include(e => e.Receiver).Include(e => e.Status).Where(p => p.ReceiverId == receiverId).ToListAsync();
        }

        public async Task<FinalBill> GetFinalBillByPaymentSolution(int id)
        {
            return await appDbContext.FinalBills.FirstOrDefaultAsync(e => e.PaymnetSolutionId == id);
        }
    }
}
