
using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Web.Services.Interfaces
{
    public interface IReceiversTableService
    {
        Task<IEnumerable<ReceiversTable>> GetReceiversTables();
        Task<ReceiversTable> GetReceiversTable(int Id);
        Task<ReceiversTable> GetReceiverByName(string name);

    }
}
