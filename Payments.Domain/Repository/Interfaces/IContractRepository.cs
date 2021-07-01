using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> GetContracts();
        Task<Contract> GetContract(int Id);

        Task<IEnumerable<Contract>> GetContractsByPayer(string name);

        Task<Contract> UpdateContractActivation(Contract contract);
    }
}
