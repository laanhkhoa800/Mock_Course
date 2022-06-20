using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class EarningServices: IEarningServices
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public EarningServices(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetail>> GetAllEarningAsync(int month, int year, Guid id)
        {
            var incompleteSpec = new GetOrderDetail(month, year, id);
            var item = await _orderDetailRepository.ListAsync(incompleteSpec);
            return item;
        }

        public Task<OrderDetail> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDetail>> GetEarningAsync(Guid id)
        {
            var incompleteSpec = new GetEarning(id);
            var item = await _orderDetailRepository.ListAsync(incompleteSpec);
            return item;
        }
    }
}
