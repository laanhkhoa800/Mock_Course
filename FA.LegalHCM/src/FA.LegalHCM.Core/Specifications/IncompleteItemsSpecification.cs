using Ardalis.Specification;
using FA.LegalHCM.Core.Entities;
using System;



namespace FA.LegalHCM.Core.Specifications
{
    public class IncompleteItemsSpecification : Specification<ToDoItem>
    {
        public IncompleteItemsSpecification()
        {
            Query.Where(item => !item.IsDone);
        }
    }

    public class GetDetailCourse : Specification<Course>
    {
        public GetDetailCourse(Guid id)
        {
            Query.Where(item => item.Id == id).Include(item => item.Sections).ThenInclude(item => item.Lessons);
        }
    }

    public class GetAllItem : Specification<Course>
    {
        public GetAllItem()
        {
            Query.Where(item => true).Include(item => item.SubCategory);
        }
    }

    public class GetApproveItem : Specification<Course>
    {
        public GetApproveItem()
        {
            Query.Where(item => item.Status == "Waiting for approved").Include(item => item.SubCategory);
        }
    }

    public class GetRejectedItem : Specification<Course>
    {
        public GetRejectedItem()
        {
            Query.Where(item => item.IsRejected == true).Include(item => item.SubCategory);

        }
    }

    public class GetCourseByUser : Specification<Course>
    {
        public GetCourseByUser(Guid Id)
        {
            Query.Where(item => item.UserId == Id).Include(item => item.SubCategory);
        }
    }
    
	public class GetUpcomingCourse : Specification<Course>
    {
        public GetUpcomingCourse(Guid id)
        {
            Query.Where(item => item.UserId == id && item.Status == "Waiting for approve").Include(item => item.SubCategory);
		}
    }
    
	public class GetDraftCourse : Specification<Course>
    {
        public GetDraftCourse(Guid Id)
        {
            Query.Where(item => item.UserId == Id && item.Status == "Draft").Include(item => item.SubCategory);
        }
    }

    public class GetAllRoleItem : Specification<Role>
    {
        public GetAllRoleItem()
        {
            Query.Where(item => true).Include(item => item.RolePermissions).ThenInclude(item => item.Permission);
        }
    }
    public class GetRoleItemById : Specification<RolePermission>
    {
        public GetRoleItemById(Guid Id)
        {
            Query.Where(item => item.RoleId.Equals(Id));
        }
    }

    public class GetAllFeedBack : Specification<Feedback>
    {
        public GetAllFeedBack()
        {
            Query.Where(item => true).Include(x => x.User);
        }
    }

    public class SearchFeedBack : Specification<Feedback>
    {
        //query search feedback
        public SearchFeedBack(string input)
        {
            Query.Where(item => item.Content.Contains(input) || item.Email.Contains(input) || item.CreateAt.ToString().Contains(input)).Include(x => x.User);
        }
    }

    public class GetPayout : Specification<Payout>
    {
        public GetPayout()
        {
            Query.Where(item => true).Include(x => x.Instructor);
        }

        public GetPayout(Guid id)
        {
            Query.Where(item => item.InstructorId == id);
        }
    }


    public class SearchPayout : Specification<Payout>
    {
        public SearchPayout(string input)
        {
            Query.Where(item => item.Instructor.UserName.Contains(input) || item.Price.ToString().Contains(input) || item.Remark.Contains(input) || item.Status.Contains(input)).Include(x => x.Instructor);
        }
    }

    public class GetAllReview : Specification<Review>
    {
        //query get all review
        public GetAllReview(Guid id)
        {
            Query.Where(item => item.UserId.Equals(id));
        }
    }
    public class GetEnrollmentById : Specification<Enrollment>
    {
        //query get courses by user id
        public GetEnrollmentById(Guid id)
        {
            Query.Where(item => item.UserId.Equals(id)).Include(x=>x.Reviews);
        }
    }
    public class GetReviewById : Specification<Review>
    {
        //query get review by courses id
        public GetReviewById(Guid id)
        {
            Query.Where(item => item.EnrollmentId.Equals(id));
        }
    }
   

    public class GetOrderDetail : Specification<OrderDetail>
    {
        public GetOrderDetail(int month, int year, Guid id)
        {
            Query.Where(item => item.PurchasedDay.Year == year && item.PurchasedDay.Month == month && item.Course.UserId == id).Include(item => item.Course);
        }
    }

    public class GetEarning : Specification<OrderDetail>
    {
        public GetEarning(Guid id)
        {
            Query.Where(item => item.Course.UserId == id).Include(item => item.Course).ThenInclude(item => item.User);
        }
    }
}
