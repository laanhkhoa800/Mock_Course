using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.DetailStudent
{
    public class ListDiscussion : BaseAsyncEndpoint
    {
        private readonly IStudentService _studentService;

        public ListDiscussion(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/DetailStudent/Discussion")]
        [SwaggerOperation(
            Summary = "Get discussion list from student id",
            Description = "Get discussion list from student id",
            OperationId = "DetailStudent.Discussion",
            Tags = new[] { "DetailStudentEndpoints" })
        ]

        //get discussion list from student id
        public async Task<ActionResult<List<DiscussionResponse>>> GetAllDiscussionAsync(Guid id, CancellationToken cancellationToken)
        {
            var items = (await _studentService.GetDiscussionAsync(id))
                .Select(x => new DiscussionResponse
                {
                    UserName = x.User.UserName,
                    Comment = x.Comment,
                    CreateAt = x.CreateAt,
                    Avatar = x.User.Avatar,
                    Like = x.Like,
                    DisLike = x.DisLike
                });

            return Ok(items);
        }
    }
}
