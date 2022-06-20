using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface IStatementService
    {
        Task<List<OrderDetail>> GetAllByMonth(int month, Guid id);

        Task<OrderDetail> GetOrderById(Guid userId, Guid courseId);
    }
}
