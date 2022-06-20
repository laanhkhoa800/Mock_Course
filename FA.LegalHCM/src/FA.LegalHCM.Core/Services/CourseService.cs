using Ardalis.Result;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FA.LegalHCM.Class;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository _repository;
        private readonly Cloudinary _cloudinary;

        public CourseService(IRepository repository, Cloudinary cloudinary)
        {
            _repository = repository;
            _cloudinary = cloudinary;
        }

        public async Task<Course> GetDetailCourse(Guid id)
        {
            var incompleteSpec = new GetDetailCourse(id);

            try
            {
                var items = await _repository.ListAsync(incompleteSpec);

                return items.First();
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<Course>.Error(new[] { ex.Message });
            }
        }
        
        public async Task<List<Course>> GetAllCourse<Course>()
        {
            var incompleteSpec = new GetAllItem();
            try
            {
                var items = await _repository.ListAsync(incompleteSpec);

                return new List<Course>((IEnumerable<Course>)items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Course>>.Error(new[] { ex.Message });
            }
        }

        public async Task<List<Course>> GetApproveCourse<Course>()
        {
            var incompleteSpec = new GetApproveItem();
            try
            {
                var items = await _repository.ListAsync(incompleteSpec);

                return new List<Course>((IEnumerable<Course>)items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Course>>.Error(new[] { ex.Message });
            }
        }

        public async Task<List<Course>> GetRejectedCourse<Course>()
        {
            var incompleteSpec = new GetRejectedItem();
            try
            {
                var items = await _repository.ListAsync(incompleteSpec);

                return new List<Course>((IEnumerable<Course>)items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Course>>.Error(new[] { ex.Message });
            }
        }
        
        /// <summary>
        /// Update Course's Status to Waiting for approval
        /// </summary>
        /// <returns>Value of updated result</returns>
        public async Task<bool> RejectedCourse(Guid id)
        {
            try
            {
                //find Course by Id
                Course course = await _repository.GetByIdAsync<Course>(id);

                //Check status must be "Waiting for approved"
                if (course.Status.Trim().ToLower() != "Waiting for approved".ToLower())
                    return false;

                //Updated Course's Status
                course.Status = "Draff";

                //Set updated date
                course.UpdateAt = DateTime.Now;

                //Update and SaveChange
                if (await _repository.UpdateAsync<Course>(course) == 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<bool>.Error(new[] { ex.Message });
            }
        }
        
        /// <summary>
        /// Update Course's Feature
        /// </summary>
        /// <returns>Value of updated result</returns>
        public async Task<bool> Feature(Guid id)
        {
            try
            {
                //find Course by Id
                Course course = await _repository.GetByIdAsync<Course>(id);

                //Check status must be "Active"
                if (course.Status.Trim().ToLower() != "Active".ToLower())
                    return false;

                //Updated Course's feature
                course.IsFeatured = !course.IsFeatured;

                //Set updated date
                course.UpdateAt = DateTime.Now;

                //Update and SaveChange
                if (await _repository.UpdateAsync<Course>(course) == 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<bool>.Error(new[] { ex.Message });
            }
        }
        
        /// <summary>
        /// Update Course's IsBestSeller to true or false
        /// </summary>
        /// <returns>Value of updated result</returns>
        public async Task<bool> BestSeller(Guid id)
        {
            try
            {
                //find Course by Id
                Course course = await _repository.GetByIdAsync<Course>(id);

                //Check status must be "Active"
                if (course.Status.Trim().ToLower() != "Active".ToLower())
                    return false;

                //Updated Course's IsBestSeller
                course.IsBestSeller = !course.IsBestSeller;

                //Set updated date
                course.UpdateAt = DateTime.Now;

                //Update and SaveChange
                if (await _repository.UpdateAsync<Course>(course) == 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<bool>.Error(new[] { ex.Message });
            }
        }
        
        /// <summary>
        /// Update Course's Status to Blocked or last status
        /// </summary>
        /// <returns>Value of updated result</returns>
        public async Task<bool> BlockedCourse(Guid id)
        {
            try
            {
                //find Course by Id
                Course course = await _repository.GetByIdAsync<Course>(id);

                //Check Course's Status
                if (course.IsBlocked)
                {
                    course.IsBlocked = false;

                    if (course.IsFeatured || course.IsBestSeller)
                        course.Status = "Active";
                    else if (course.IsRejected)
                        course.Status = "Draff";
                    else
                        course.Status = "No Data";
                }
                else
                {
                    course.IsBlocked = true;

                    course.Status = "Block";
                }

                //Set updated date
                course.UpdateAt = DateTime.Now;

                //Update and SaveChange
                if (await _repository.UpdateAsync<Course>(course) == 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<bool>.Error(new[] { ex.Message });
            }
        }
        
        /// <summary>
        /// Update Course's Status to Active
        /// </summary>
        /// <returns>Value of updated result</returns>
        public async Task<bool> ApprovedCourse(Guid id)
        {
            try
            {
                //find Course by Id
                Course course = await  _repository.GetByIdAsync<Course>(id);

                //Check status must be "Waiting for approved"
                if (course.Status.Trim().ToLower() != "Waiting for approved".ToLower())
                    return false;

                //Updated Course's Status
                course.Status = "Active";

                //Set updated date
                course.UpdateAt = DateTime.Now;

                //Update and SaveChange
                if (await _repository.UpdateAsync<Course>(course) == 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<bool>.Error(new[] { ex.Message });
            }
        }

        /// <summary>
        /// Create new course
        /// </summary>
        /// <returns>Course just created</returns>
        public async Task<Course> CreateCourse(Course course)
        {
            course.CreateAt = DateTime.Now;
            course.Status = "No Data";

            return await _repository.AddAsync<Course>(course);
        }

        /// <summary>
        /// Get discount of promotion
        /// </summary>
        /// <param name="promotionId">Id of promotion</param>
        /// <returns>Value of discount</returns>
        public async Task<decimal> GetDiscount(Guid promotionId)
        {
            Promotion promotion = await _repository.GetByIdAsync<Promotion>(promotionId);

            return promotion.DiscountPercent;
        }

        /// <summary>
        /// Check course must be owned user
        /// </summary>
        /// <param name="courseId">course Id</param>
        /// <param name="userId">user Id</param>
        /// <returns>true if it's already exits</returns>
        public async Task<bool> CheckCourseOfUser(Guid courseId, Guid userId)
        {
            Course course = await _repository.GetByIdAsync<Course>(courseId);

            if (course?.UserId == userId)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Upload to Cloudinary for image and trailer video
        /// </summary>
        /// <param name="courseId">course id</param>
        /// <param name="image">image file</param>
        /// <param name="trailer">image file</param>
        /// <returns>true if it's success</returns>
        public async Task<bool> UpdateView(Guid courseId, IFormFile image, IFormFile trailer)
        {
            //find Course by Id
            Course course = await _repository.GetByIdAsync<Course>(courseId);

            //set url for uploaded file
            course.ImageUrl = await UploadFile(image);
            course.TrailerUrl = await UploadFile(trailer);

            course.UpdateAt = DateTime.Now;

            //Update and SaveChange
            if (await _repository.UpdateAsync<Course>(course) == 1)
            {
                return true;
            }

            return false;
        }

        private async Task<string> UploadFile(IFormFile file)
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

        /// <summary>
        /// Create by:
        ///         Lesson table
        ///         Section table
        /// </summary>
        /// <returns>true if it's success</returns>
        public async Task<bool> CreateCourseContent(CourseContent courseContent)
        {
            Section section = new Section();

            //Set value of Section
            section.CourseId = courseContent.CourseId;
            section.Title = courseContent.CourseContentTitle;
            section.TotalTime = GetTotalTime(courseContent.LessonContents);
            section.CreateAt = DateTime.Now;

            //Add new Section and Lesson
            return await AddListLesson((await _repository.AddAsync<Section>(section)).Id, courseContent.LessonContents);
        }

        /// <summary>
        /// Get total time of total Lessons
        /// </summary>
        /// <param name="lessons"></param>
        /// <returns>value of Total time</returns>
        private int GetTotalTime(List<LessonContent> lessons)
        {
            int result = 0;

            foreach (LessonContent lesson in lessons)
            {
                result += (int)lesson.Duration;
            }

            return result;
        }

        /// <summary>
        /// Insert element of Lesson list into database
        /// </summary>
        /// <param name="sectionId">Id of Section want relationship</param>
        /// <param name="lessonContents">Lesson list</param>
        /// <returns>true if it's success</returns>
        private async Task<bool> AddListLesson(Guid sectionId, List<LessonContent> lessonContents)
        {
            try
            {
                foreach (LessonContent lessonContent in lessonContents)
                {
                    Lesson lesson = new Lesson();

                    //Set value for element in Lesson list
                    lesson.SectionId = sectionId;
                    lesson.Title = lessonContent.LessonTitle;
                    lesson.CreateAt = DateTime.Now;
                    lesson.VideoUrl = await UploadFile(lessonContent.File);
                    lesson.Volume = lessonContent.Volume;
                    lesson.Duration = lessonContent.Duration;
                    lesson.Sort = lessonContent.Sort;

                    await _repository.AddAsync<Lesson>(lesson);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Section by id
        /// </summary>
        /// <param name="sectionId">section id</param>
        /// <returns>true if it's success</returns>
        public async Task<bool> DeleteSection(Guid sectionId)
        {
            try
            {
                await _repository.DeleteListAsync<Lesson>(item => item.SectionId == sectionId);

                await _repository.DeleteByIdAsync<Section>(sectionId);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get UserId by SectionId
        /// </summary>
        /// <param name="sectionId">section id</param>
        /// <returns>id of userId</returns>
        public async Task<Guid> GetUserIdBySectionId(Guid sectionId)
        {
            return (await _repository.Find<Section>(item => item.Id == sectionId)
                .Include(item => item.Course)
                .SingleOrDefaultAsync()).Course.UserId;
        }

        /// <summary>
        /// confirm create course or set as Draff
        /// </summary>
        /// <param name="courseId">Course Id</param>
        /// <returns>true if it's success</returns>
        public async Task<bool> UpdateExtra(Guid courseId, string status)
        {
            try
            {
                //find Course by Id
                Course course = await _repository.GetByIdAsync<Course>(courseId);
                
                //Set values
                course.UpdateAt = DateTime.Now;
                if (status.Trim().ToLower() == "draff")
                    course.Status = "Draff";
                course.Status = "Waiting for approved";

                //Update and SaveChange
                if (await _repository.UpdateAsync<Course>(course) == 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<bool>.Error(new[] { ex.Message });
            }
        }

        /// <summary>
        /// Get Course creating
        /// </summary>
        /// <returns>Course</returns>
        public Course GetCourseCreating(Guid userId)
        {
            return  _repository
                .Find<Course>(item => item.Status.ToLower().Equals("no data"))
                .ToList().Where(item => item.UserId == userId)
                .ToList().Where(item => (DateTime.Now - item.CreateAt).Hours <= 1)
                .FirstOrDefault();
        }
        
        public async Task UpdateCourse(Course request, IFormFile image, IFormFile trailer)
        {
            try
            {
                var existingItem = await _repository.GetByIdAsync<Course>(request.Id);

                existingItem.Title = request.Title;
                existingItem.Description = request.Description;
                existingItem.ImageUrl = request.ImageUrl;
                existingItem.TrailerUrl = request.TrailerUrl;
                existingItem.Status = request.Status;
                existingItem.Subtitle = request.Subtitle;
                existingItem.OriginPrice = request.OriginPrice;
                existingItem.UpdateAt = DateTime.Now;
                existingItem.PromotionId = request.PromotionId;
                existingItem.SubCategoryId = request.SubCategoryId;
                existingItem.LanguageId = request.LanguageId;
                await UpdateView(request.Id, image, trailer);

                await _repository.UpdateAsync(existingItem);
            }
            catch (Exception ex)
            {
                Result<Course>.Error(new[] { ex.Message });
            }
        }

        public async Task UpdateSection(Section request)
        {
            try
            {
                var existingItem = await _repository.GetByIdAsync<Section>(request.Id);

                existingItem.Title = request.Title;
                existingItem.TotalTime = request.TotalTime;
                existingItem.UpdateAt = DateTime.Now;

                await _repository.UpdateAsync(existingItem);
            }
            catch (Exception ex)
            {
                Result<Section>.Error(new[] { ex.Message });
            }
        }

        public async Task UpdateLesson(Lesson request, IFormFile file)
        {
            try
            {
                var existingItem = await _repository.GetByIdAsync<Lesson>(request.Id);

                existingItem.Title = request.Title;
                existingItem.TotalTime = request.TotalTime;
                existingItem.UpdateAt = DateTime.Now;
                existingItem.Volume = request.Volume;
                existingItem.Duration = request.Duration;
                existingItem.VideoUrl = await UploadFile(file); ;

                await _repository.UpdateAsync(existingItem);
            }
            catch (Exception ex)
            {
                Result<Course>.Error(new[] { ex.Message });
            }
        }

        public async Task<bool> GiveForReview(Guid id)
        {
            try
            {
                //find Course by Id
                Course course = await _repository.GetByIdAsync<Course>(id);

                //Check status must be "Waiting for approved"
                if (course.Status.Trim().ToLower() != "Draft".ToLower())
                    return false;

                //Updated Course's Status
                course.Status = "Waiting for approve";

                //Set updated date
                course.UpdateAt = DateTime.Now;

                //Update and SaveChange
                if (await _repository.UpdateAsync<Course>(course) == 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<bool>.Error(new[] { ex.Message });
            }
        }

        public async Task<List<Course>> GetCourseByUser<Course>(Guid Id)
        {
            var incompleteSpec = new GetCourseByUser(Id);
            try
            {
                var items = await _repository.ListAsync(incompleteSpec);

                return new List<Course>((IEnumerable<Course>)items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Course>>.Error(new[] { ex.Message });
            }
        }

        public async Task<List<Course>> GetDraftCourse<Course>(Guid id)
        {
            var incompleteSpec = new GetDraftCourse(id);
            try
            {
                var items = await _repository.ListAsync(incompleteSpec);

                return new List<Course>((IEnumerable<Course>)items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Course>>.Error(new[] { ex.Message });
            }
        }

        public async Task<List<Course>> GetUpcomingCourse<Course>(Guid id)
        {
            var incompleteSpec = new GetUpcomingCourse(id);
            try
            {
                var items = await _repository.ListAsync(incompleteSpec);

                return new List<Course>((IEnumerable<Course>)items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Course>>.Error(new[] { ex.Message });
            }
        }
        
        public async Task<bool> DraftCourse(Guid id)
        {
            try
            {
                //find Course by Id
                Course course = await _repository.GetByIdAsync<Course>(id);

                //Check status must be "Waiting for approved"
                if (course.Status.Trim().ToLower() != "Waiting for approved".ToLower())
                    return false;

                //Updated Course's Status
                course.Status = "Draft";

                //Set updated date
                course.UpdateAt = DateTime.Now;

                //Update and SaveChange
                if (await _repository.UpdateAsync<Course>(course) == 1)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<bool>.Error(new[] { ex.Message });
            }
        }
    }
}
