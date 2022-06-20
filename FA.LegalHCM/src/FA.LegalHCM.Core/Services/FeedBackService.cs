using Ardalis.Result;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IRepository _repository;
        private readonly Cloudinary _cloudinary;
        public FeedBackService(IRepository repository, Cloudinary cloudinary)
        {
            _repository = repository;
            _cloudinary = cloudinary;
        }
        /// <summary>
        /// get all list of feedback
        /// </summary>
        /// <param name="input">param is FeedBack Object</param>
        /// <returns>list of feedback</returns>

        public async Task<List<Feedback>> GetAllFeedBacks()
        {
            var incompleteSpec = new GetAllFeedBack();

            try
            {
                var items = await _repository.ListAsync<Feedback>(incompleteSpec);

                return new List<Feedback>((IEnumerable<Feedback>)items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Feedback>>.Error(new[] { ex.Message });
            }
        }

        // ThaoTT26 code: addnewfeedback and upload file
        public async Task<Feedback> AddNewFeedback(Feedback feedback)
        {
            return await _repository.AddAsync<Feedback>(feedback);
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            //kiểm tra có ảnh hay không
            if (file != null)
            {
                #region Upload image to Cloudinary
                var results = new List<Dictionary<string, string>>();

                IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
                var result = await _cloudinary.UploadAsync(new ImageUploadParams
                {
                    File = new FileDescription(file.FileName,
                        file.OpenReadStream()),
                    Tags = "backend_PhotoAlbum"
                }).ConfigureAwait(false);

                //nếu upload thất bại
                if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return "";
                }

                var imageProperties = new Dictionary<string, string>();
                foreach (var token in result.JsonObj.Children())
                {
                    //tìm thuộc tính url để gán cho post
                    if (token is JProperty prop)
                    {
                        if (prop.Name == "url")
                            return prop.Value.ToString();
                    }
                }

                results.Add(imageProperties);
                #endregion
            }

            return "";
        }
    }
}
