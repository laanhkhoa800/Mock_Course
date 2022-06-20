using Ardalis.Result;
using FA.LegalHCM.Core.Entities;

using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IRepository _repository;

        public LanguageService(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get list of all languages
        /// </summary>
        /// <returns>List Language</returns>
        public async Task<List<Language>> GetAllLanguages()
        {
            // get list of language
            return await _repository.ListAsync<Language>();
        }

        /// <summary>
        /// Create new language
        /// </summary>
        /// <param name="language">param is Language object</param>
        /// <returns>new language</returns>
    	public async Task<Language> AddLanguage(Language language)
    	{
            // return new language
            return await _repository.AddAsync<Language>(language);
    	}

        /// <summary>
        /// Find language by Id
        /// </summary>
        /// <param name="languageId">param is Guid</param>
        /// <returns>Language</returns>
        public async Task<Language> GetLanguageByID(Guid languageId)
        {
            // find language by id and return
            return await _repository.GetByIdAsync<Language>(languageId);
        }

        /// <summary>
        /// Update language
        /// </summary>
        /// <param name="languageId">param is Guid</param>
        /// <param name="request">param is Language object</param>
        /// <returns>true if update successful and false if update fail</returns>
        public async Task<bool> EditLanguage(Guid languageId, Language request)
        {
            // find existing language by id
            Language existingLanguage = await _repository.GetByIdAsync<Language>(languageId);
            if (existingLanguage == null)
            {
                return false;
            }

            //update value
            existingLanguage.Name = request.Name;
            existingLanguage.Status = request.Status;

            // compare number of row affected with 0
            try
            {
                //update success
                await _repository.UpdateAsync<Language>(existingLanguage);
                return true;
            }
            catch
            {
                //update fail
                return false;
            }          
        }

        /// <summary>
        /// Delete language
        /// </summary>
        /// <param name="languageId">param is Guid</param>
        /// <returns>true if delete successful and false if delete fail</returns>
        public async Task<bool> DeleteLanguage(Guid languageId)
        {
            // find existing language by id
            Language existingLanguage = await _repository.GetByIdAsync<Language>(languageId);
            if (existingLanguage == null)
            {
                return false;
            }

            try
            {
                //delete success
                await _repository.DeleteAsync<Language>(existingLanguage);
                return true;
            }
            catch
            {
                //delete fail
                return false;
            }
           
        }
    }
}
