using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using FA.LegalHCM.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface IInstructorService
    {
        Task<Result<List<User>>> GetAllIntructor(string searhString);
        Task<Result<User>> GetByIdAsync(Guid id);
        Task<Result<object>> ChangeBlockAsync(Guid id);
        Task<Result<object>> ChangePasswordAsync(Guid id, string currentPassword, string newPassword, string confirmPassword);
        Task<Result<object>> UploadAvatarAsync(Guid id, IFormFile file);
        Task<Result<User>> UpdateProfileAsync(Guid id, string email, string userName);

    }
}
