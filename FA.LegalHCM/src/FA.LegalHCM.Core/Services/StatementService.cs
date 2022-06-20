using Ardalis.Result;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class StatementService : IStatementService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public StatementService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetail>> GetAllByMonth(int month, Guid id)
        {
            var incompleteSpec = new PayoutIncompleteItemsSpecification(month, id);
            try
            {
                return await _orderDetailRepository.ListAsync<OrderDetail>(incompleteSpec);
            }
            catch(Exception ex)         
            {
                // TODO: Log details here
                return Result<List<OrderDetail>>.Error(new[] { ex.Message });
            }
        }

        public async Task<OrderDetail> GetOrderById(Guid userId, Guid courseId)
        {
            try
            {
                return await _orderDetailRepository.ListAsync<OrderDetail>().Where(x => x.CourseId == courseId && x.UserId == userId).Include(x => x.Course).Include(x => x.User).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<OrderDetail>.Error(new[] { ex.Message });
            }
        }
    }
}
