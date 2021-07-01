
using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IPayersTableService
    {
        Task<IEnumerable<PayersTable>> GetPayersTables();
        Task<PayersTable> GetPayersTable(int Id);

        Task<PayersTable> GetPayerByName(string name);
    }
}
