using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.Domain;
using Payments.Domain.Repository.Interfaces;
using Payments.Model.Entities;

namespace Payments.Domain.Repository
{
    public class PaymentScheduleRepository : IPaymentScheduleRepository
    {

        private readonly AppDbContext appDbContext;

        public PaymentScheduleRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<PaymentSchedule>> GetPaymentSchedules()
        {
            
          

            return await appDbContext.PaymentSchedules.Include(e=> e.PaymentInformation).Include(e=>e.PaymentSolution).ToListAsync();
        }
        public async Task<PaymentSchedule> GetPaymentSchedule(int Id)
        {
            return await appDbContext.PaymentSchedules.FirstOrDefaultAsync(e => e.IdPaymentSchedule == Id);
        }


        public async Task<PaymentSchedule> AddPaymentSchedule(PaymentSchedule Solution)
        {
            var result = await appDbContext.PaymentSchedules.AddAsync(Solution);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }
       
        public async Task<PaymentSchedule> UpdatePaymentSchedule(PaymentSchedule Solution)
        {
            var result = await appDbContext.PaymentSchedules.Include(e => e.PaymentInformation).Include(e => e.PaymentSolution).FirstOrDefaultAsync(e => e.IdPaymentSchedule == Solution.IdPaymentSchedule);
            if(result != null)
            {
                //fill for update 
                result.PaymentSolutionId = Solution.PaymentSolutionId;
                result.PaymnetInformationId= Solution.PaymnetInformationId;
                result.StartOfSchedule = Solution.StartOfSchedule;
                result.EntOfSchedule = Solution.EntOfSchedule;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        public async Task<PaymentSchedule> DeletePaymentSchedule(int Id)
        {
            var result = await appDbContext.PaymentSchedules.FirstOrDefaultAsync(e => e.IdPaymentSchedule == Id);
            if( result != null)
            {
                appDbContext.PaymentSchedules.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<IEnumerable<PaymentSchedule>> GetPaymentSchedulesBySolutionId(int id)
        {
            return await appDbContext.PaymentSchedules.Include(p=>p.PaymentInformation).Where(p=>p.PaymentSolutionId == id).ToListAsync();
        }

        public async Task<PaymentSchedule> IsPaid(int Id)
        {
            var result = await appDbContext.PaymentSchedules.FirstOrDefaultAsync(e => e.IdPaymentSchedule == Id);
            if (result != null)
            { 
                result.IsPaid = true;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
