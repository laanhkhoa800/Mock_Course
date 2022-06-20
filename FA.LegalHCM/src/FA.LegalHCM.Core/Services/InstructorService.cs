using Ardalis.Result;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications.InstrructorSpec;
using FA.LegalHCM.Core.Specifications.InstructorSpec;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly UserManager<User> _userManager;
        private readonly Cloudinary _cloudinary;

        public InstructorService(IInstructorRepository instructorRepository, UserManager<User> userManager,
            Cloudinary cloudinary)
        {
            _instructorRepository = instructorRepository;
            _userManager = userManager;
            _cloudinary = cloudinary;
        }

        public async Task<Result<List<User>>> GetAllIntructor(string searhString = null)
        {
            try
            {
                if (searhString == null || searhString.Trim() == "")
                {
                    var instructorItemsSpec = new InstructorItemsSpecification();
                    var list = await _instructorRepository.ListInstructorAsync<User>(instructorItemsSpec);
                    return new Result<List<User>>(list);

                }
                else
                {
                    var instructorSearchSpec = new InstructorSearchSpecification(searhString);
                    var list = await _instructorRepository.SearchInstructorAsync<User>(instructorSearchSpec);
                    return new Result<List<User>>(list);
                }

            }
            catch (Exception ex)
            {
                return Result<List<User>>.Error(new[] { ex.Message });
            }
        }

        public async Task<Result<User>> GetByIdAsync(Guid id)
        {
            if (id == null)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(id),
                    ErrorMessage = $"{nameof(id)} is required."
                });
                return Result<User>.Invalid(errors);
            }

            try
            {
                var items = await _instructorRepository.GetInstructorByIdAsync<User>(id)
                                                       .Include(u => u.Subscripers)
                                                       .Include(u => u.Enrollments)
                                                       .Include(u => u.DiscussionSenders)
                                                       .Include(u => u.Discussions)
                                                       .Include(u => u.Courses)
                                                       .FirstOrDefaultAsync(u => u.Id.Equals(id));

                if (items != null)
                {
                    return new Result<User>(items);
                }
                return Result<User>.Error(new[] { "Error. Can't get instructor" });
            }
            catch (Exception ex)
            {
                return Result<User>.Error(new[] { ex.Message });
            }
        }

        public async Task<Result<object>> ChangeBlockAsync(Guid id)
        {
            if (id == null)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(id),
                    ErrorMessage = $"{nameof(id)} is required."
                });
                return Result<object>.Invalid(errors);
            }

            try
            {
                var item = await _instructorRepository.GetInstructorByIdAsync<User>(id)
                                                       .FirstOrDefaultAsync(u => u.Id.Equals(id));

                if (item == null)
                {
                    return Result<bool>.Error(new[] { "Error. Can't get user" });
                }

                //update Status
                item.Status = !item.Status;
                //update entity in database
                await _instructorRepository.UpdateInstructorAsync(item);
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Error(new[] { ex.Message });
            }
        }

        public async Task<Result<object>> ChangePasswordAsync(Guid id, string currentPassword, string newPassword, string confirmPassword)
        {
            if (id == null)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(id),
                    ErrorMessage = $"{nameof(id)} is required."
                });
                return Result<object>.Invalid(errors);
            }

            try
            {
                var item = await _instructorRepository.GetInstructorByIdAsync<User>(id).FirstOrDefaultAsync(u => u.Id.Equals(id));

                if (item == null)
                {
                    return Result<bool>.Error(new[] { "Error. Can't get user" });
                }

                //check password current
                var checkPass = await _userManager.CheckPasswordAsync(item, currentPassword);

                //check current password
                if (checkPass == false)
                {
                    return Result<bool>.Error(new[] { "Current Password is incorrect" });
                }
                //check new password match confirm password
                if (!confirmPassword.Equals(newPassword))
                {
                    return Result<bool>.Error(new[] { "Error. Confim Password is not match New Password" });
                }

                //hash new password
                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                item.PasswordHash = passwordHasher.HashPassword(item, newPassword);
                //update entity in database
                await _instructorRepository.UpdateInstructorAsync(item);
                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Error(new[] { ex.Message });
            }
        }

        public async Task<Result<object>> UploadAvatarAsync(Guid id, IFormFile file)
        {
            if (id == null)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(id),
                    ErrorMessage = $"{nameof(id)} is required."
                });
                return Result<object>.Invalid(errors);
            }

            try
            {
                var user = await _instructorRepository.GetInstructorByIdAsync<User>(id)
                                                     .FirstOrDefaultAsync(u => u.Id.Equals(id));

                if (user == null)
                {
                    return Result<bool>.Error(new[] { "Error. Can't get user" });
                }

                if (file == null)
                {                   
                    return new Result<bool>(true);
                }
             
                //Upload image to Cloudinary
                var results = new List<Dictionary<string, string>>();
                IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
                var result = await _cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(file.FileName,
                    file.OpenReadStream()),
                    Tags = "avatar",
                    Folder="avatar"
                }).ConfigureAwait(false);

                //upload failed
                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return Result<bool>.Error(new[] { "The uploaded file is not valid" });
                }

                var imageProperties = new Dictionary<string, string>();
                foreach (var token in result.JsonObj.Children())
                {
                    //find url and assign to user.Avatar
                    if (token is JProperty prop)
                    {
                        if (prop.Name == "url")
                            user.Avatar = prop.Value.ToString();
                    }
                }

                results.Add(imageProperties);

                //update avatar
                await _instructorRepository.UpdateInstructorAsync(user);
                return new Result<bool>(true);
                /* }*/
            }
            catch (Exception ex)
            {
                return Result<bool>.Error(new[] { ex.Message });
            }
        }

        public async Task<Result<User>> UpdateProfileAsync(Guid id, string email, string userName)
        {
            if (id == null)
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(id),
                    ErrorMessage = $"{nameof(id)} is required."
                });
                return Result<User>.Invalid(errors);
            }

            try
            {
                var item = await _instructorRepository.GetInstructorByIdAsync<User>(id).FirstOrDefaultAsync(u => u.Id.Equals(id));

                if (item == null)
                {
                    return Result<User>.Error(new[] { "Error. Can't get user" });
                }

                //check email
                var emailExistedSpec = new EmailExistedSpecification(email);
                var userExisted = await _instructorRepository.GetByEmail<User>(emailExistedSpec);

                //check current password
                if (userExisted != null)
                {
                    return Result<User>.Error(new[] { "Email is existed" });
                }

                //check username
                var userNameExistedSpec = new EmailExistedSpecification(userName);
                userExisted = await _instructorRepository.GetByUserName<User>(userNameExistedSpec);

                //check current password
                if (userExisted != null)
                {
                    return Result<User>.Error(new[] { "UserName is existed" });
                }

                //update entity in database
                item.Email = email;
                item.UserName = userName;
                await _instructorRepository.UpdateInstructorAsync(item);
                return new Result<User>(item);
            }
            catch (Exception ex)
            {
                return Result<User>.Error(new[] { ex.Message });
            }
        }
   
    }
}
