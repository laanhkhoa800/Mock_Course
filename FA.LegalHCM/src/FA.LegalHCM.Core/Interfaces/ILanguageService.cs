using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface ILanguageService
    {
        /// <summary>
        /// Get list of all languages
        /// </summary>
        /// <returns>List Language</returns>
        public Task<List<Language>> GetAllLanguages();

        /// <summary>
        /// Create new language
        /// </summary>
        /// <param name="language">param is Language object</param>
        /// <returns>new language object</returns>
        public Task<Language> AddLanguage(Language language);

        /// <summary>
        /// Find language by Id
        /// </summary>
        /// <param name="languageId">param is Guid</param>
        /// <returns>Language</returns>
        public Task<Language> GetLanguageByID(Guid languageId);

        /// <summary>
        /// Update language
        /// </summary>
        /// <param name="languageId">param is Guid</param>
        /// <param name="request">param is Language object</param>
        /// <returns>true if update successful and false if update fail</returns>
        public Task<bool> EditLanguage(Guid languageId, Language request);

        /// <summary>
        /// Delete language
        /// </summary>
        /// <param name="languageId">param is Guid</param>
        /// <returns>true if delete successful and false if delete fail</returns>
        public Task<bool> DeleteLanguage(Guid languageId);
    }
}
