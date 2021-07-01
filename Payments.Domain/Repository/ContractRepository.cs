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
    public class ContractRepository : IContractRepository
    {

        private readonly AppDbContext appDbContext;

        public ContractRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext; 
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
            
           // var a = appDbContext.ContractTable.ToList();

            return await appDbContext.Contracts.ToListAsync();
        }
        public async Task<Contract> GetContract(int Id)
        {
            return await appDbContext.Contracts.FirstOrDefaultAsync(e => e.IdContract == Id);
        }

        public async Task<IEnumerable<Contract>> GetContractsByPayer(string name)
        {
            var a = await appDbContext.Contracts.ToListAsync();
            IEnumerable<Contract> temp = (from c in a where c.PayersName == name select c);

            return temp;
        }

        public async Task<Contract> UpdateContractActivation(Contract contract)
        {
            var result = await appDbContext.Contracts.FirstOrDefaultAsync(e => e.IdContract == contract.IdContract);
            if (result != null)
            {
                result.IsActivated = contract.IsActivated;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
