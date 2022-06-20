using Ardalis.Result;
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
    public class PayoutService : IPayoutService
    {
        private readonly IRepository _repository;

        public PayoutService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Payout>> GetAllPayout()
        {
            var incompleteSpec = new GetPayout();
            try
            {
                return await _repository.ListAsync<Payout>(incompleteSpec);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Payout>>.Error(new[] { ex.Message });
            }

        }

        public async Task<Payout> GetById(Guid id)
        {
            try
            {
                return await _repository.GetByIdAsync<Payout>(id);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<Payout>.Error(new[] { ex.Message });
            }
        }

        public async Task<List<Payout>> GetByInstructor(Guid id)
        {
            var incompleteSpec = new GetPayout(id);
            try
            {
                return await _repository.ListAsync<Payout>(incompleteSpec);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Payout>>.Error(new[] { ex.Message });
            }
        }

        public async Task<bool> InsertPayout(Payout payout)
        {
            try
            {
                await _repository.AddAsync<Payout>(payout);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Payout>> SearchPayout(string input)
        {
            var incompleteSpec = new SearchPayout(input);
            try
            {
                return await _repository.ListAsync<Payout>(incompleteSpec);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Payout>>.Error(new[] { ex.Message });
            }
        }

        public async Task<bool> UpdatePayout(Payout payout)
        {
            try
            {
                await _repository.UpdateAsync<Payout>(payout);
                return true;
            }
            
            catch
            {
                return false;
            }
        }
    }
}
