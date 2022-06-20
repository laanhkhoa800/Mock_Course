using FA.LegalHCM.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface IFeedBackService
    {
        public Task<List<Feedback>> GetAllFeedBacks();

        /// <summary>
        /// ThaoTT26 - code Create new Feedback Enpoint
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        public Task<Feedback> AddNewFeedback(Feedback feedback);

        public Task<string> UploadFile(IFormFile file);
    }

    
}
