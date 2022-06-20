using Ardalis.Result;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class FeedBackSearchService : IFeedBackSearchService
    {
        private readonly IRepository _repository;

        public FeedBackSearchService(IRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Search list of feedback
        /// </summary>
        /// <param name="input">param is FeedBack Object</param>
        /// <returns>list of feedback</returns>
        public async Task<List<Feedback>> SearchFeedBack(string input)
        {
             var incompleteSpec = new SearchFeedBack(input);
                try
                {
                    //return list of feedback
                    return await _repository.ListAsync<Feedback>(incompleteSpec);
                }
                catch (Exception ex)
                {
                    // TODO: Log details here
                    //return error
                    return Result<List<Feedback>>.Error(new[] { ex.Message });
                }
            
        }
    }
}
