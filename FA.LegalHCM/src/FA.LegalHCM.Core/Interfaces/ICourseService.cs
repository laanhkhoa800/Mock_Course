using System;
using FA.LegalHCM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FA.LegalHCM.Class;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface ICourseService
    {
        /// <summary>
        /// This function help get course information by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>course information by id</returns>
        Task<Course> GetDetailCourse(Guid id);

        /// <summary>
        /// Update Course's Status to Waiting for approval
        /// </summary>
        /// <returns>Value of updated result</returns>
        Task<bool> RejectedCourse(Guid id);
        
        /// <summary>
        /// Update Course's Status to Blocked or last status
        /// </summary>
        /// <returns>Value of updated result</returns>
        Task<bool> BlockedCourse(Guid id);
        /// <summary>
        /// Update Course' status to Waiting for approve
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> GiveForReview(Guid id);
        /// <summary>
        /// Update Course's status to Draft
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DraftCourse(Guid id);
        /// <summary>
        /// Update Course's Status to Active
        /// </summary>
        /// <returns>Value of updated result</returns>
        Task<bool> ApprovedCourse(Guid id);
        
        /// <summary>
        /// Update Course's Status to Draff
        /// </summary>
        /// <returns>Value of updated result</returns>
        Task<bool> BestSeller(Guid id);
        
        /// <summary>
        /// Update Course's Feature
        /// </summary>
        /// <returns>Value of updated result</returns>
        Task<bool> Feature(Guid id);

        /// <summary>
        /// Create new course
        /// </summary>
        /// <returns>Course just created</returns>
        Task<Course> CreateCourse(Course course);

        /// <summary>
        /// Get discount of promotion
        /// </summary>
        /// <param name="promotionId">Id of promotion</param>
        /// <returns>Value of discount</returns>
        Task<decimal> GetDiscount(Guid promotionId);

        /// <summary>
        /// Check course must be owned user
        /// </summary>
        /// <param name="courseId">course Id</param>
        /// <param name="userId">user Id</param>
        /// <returns>true if it's true</returns>
        Task<bool> CheckCourseOfUser(Guid courseId, Guid userId);

        /// <summary>
        /// Upload to Cloudinary for image and trailer video
        /// </summary>
        /// <param name="courseId">course id</param>
        /// <param name="image">image file</param>
        /// <param name="trailer">image file</param>
        /// <returns>true if it's success</returns>
        Task<bool> UpdateView(Guid courseId, IFormFile image, IFormFile trailer);
		/// <summary>
        /// This function help get all courses
        /// </summary>
        /// <typeparam name="Course"></typeparam>
        /// <returns>lits of courses</returns>
        Task<List<Course>> GetAllCourse<Course>();
        /// <summary>
        /// This function help get all course by user
        /// </summary>
        /// <typeparam name="Course"></typeparam>
        /// <param name="Id">list of course by user</param>
        /// <returns></returns>
        Task<List<Course>> GetCourseByUser<Course>(Guid Id);
        /// <summary>
        /// This function help get all course have status is Draft
        /// </summary>
        /// <typeparam name="Course"></typeparam>
        /// <param name="id">List of draft courses</param>
        /// <returns></returns>
        Task<List<Course>> GetDraftCourse<Course>(Guid id);
        /// <summary>
        /// This function help waiting list for course approval of each instructor
        /// </summary>
        /// <typeparam name="Course"></typeparam>
        /// <returns>list for course approval of each instructor</returns>
        Task<List<Course>> GetUpcomingCourse<Course>(Guid id);
        /// <summary>
        /// This function help get waiting list for course approval
        /// </summary>
        /// <typeparam name="Course"></typeparam>
        /// <returns>Waiting list for course approval</returns>
        Task<List<Course>> GetApproveCourse<Course>();
        /// <summary>
        /// this function help get list of courses that have been rejected
        /// </summary>
        /// <typeparam name="Course"></typeparam>
        /// <returns>List of courses that have been rejected</returns>
        Task<List<Course>> GetRejectedCourse<Course>();
        /// <summary>
        /// This function help update course by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UpdateCourse(Course request, IFormFile image, IFormFile trailer);
        /// <summary>
        /// This function help update section by courseId and sectionId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UpdateSection(Section request);
        /// <summary>
        /// This function help update section by courseId and lessionId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task UpdateLesson(Lesson request, IFormFile file);

    	/// <summary>
        /// Create by:
        ///         Lesson table
        ///         Section table
        /// <param name="courseContent">requested value</param>
        /// <returns>true if it's success</returns>
        Task<bool> CreateCourseContent(CourseContent courseContent);

        /// <summary>
        /// Delete Section by id
        /// </summary>
        /// <param name="sectionId">section id</param>
        /// <returns>true if it's success</returns>
        Task<bool> DeleteSection(Guid sectionId);

        /// <summary>
        /// Get UserId by SectionId
        /// </summary>
        /// <param name="sectionId">section id</param>
        /// <returns>id of userId</returns>
        Task<Guid> GetUserIdBySectionId(Guid sectionId);

        /// <summary>
        /// confirm create course or set as Draff
        /// </summary>
        /// <param name="courseId">Course Id</param>
        /// <returns>true if it's success</returns>
        Task<bool> UpdateExtra(Guid courseId, string status);

        /// <summary>
        /// Get Course creating
        /// </summary>
        /// <returns>Course</returns>
        Course GetCourseCreating(Guid userId);
    }
}
