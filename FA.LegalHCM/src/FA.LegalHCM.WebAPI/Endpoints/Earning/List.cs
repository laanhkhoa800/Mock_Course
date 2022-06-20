using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Earning
{
    public class List : BaseAsyncEndpoint
    {
        public readonly IEarningServices _earningServices;
        public readonly IUserServices _userService;

        public List(IEarningServices earningServices, IUserServices userService)
        {
            _earningServices = earningServices;
            _userService = userService;
        }

        [HttpGet("/ListEarning")]
        [SwaggerOperation(
            Summary = "get the instructor's Earning list by month",
            Description = "get the instructor's Earning list by month",
            OperationId = "Earning.List",
            Tags = new[] { "EarningEndpoints" })
        ]
        //get the instructor's Earning list by month
        public async Task<ActionResult<List<ListEarningResponse>>> GetListEarningAsync(int month, int year, CancellationToken cancellationToken)
        {
            //get id usser
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var id = Guid.Parse(userId);

            var items = (await _earningServices.GetAllEarningAsync(month, year, id))
                .GroupBy(p => p.PurchasedDay)
                .Select(g => new ListEarningResponse
                {
                    ItemSalesCount = g.Count(),
                    Day = g.Key.ToString("dd MMMM yyyy"),
                    Earning = g.Sum(x => x.Price),
                }) ;
            return Ok(items);
        }

        [HttpGet("/Earning")]
        [SwaggerOperation(
            Summary = "get earnings of the instructor ",
            Description = "get earnings of the instructor",
            OperationId = "Earning.Count",
            Tags = new[] { "EarningEndpoints" })
        ]
        public async Task<ActionResult<List<EarningResponse>>> GetEarningAsync(CancellationToken cancellationToken)
        {
            //get id usser
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var id = Guid.Parse(userId);


            var items = (await _earningServices.GetEarningAsync(id));
            var response = new EarningResponse()
            {
                SalesEarnings = items.Sum(x => x.Price),
                YourBalance = (await _userService.GetById(id)).AvailableAmount,
                AdminCommission = (items.Sum(x => x.Price * Convert.ToDecimal(0.03)))
            }; 

            return Ok(response);
        }

        [HttpGet("/ListTopCourse")]
        [SwaggerOperation(
            Summary = "get the list of top courses by month of the instructor",
            Description = "get the list of top courses by month of the instructor",
            OperationId = "ListTopCourse.List",
            Tags = new[] { "EarningEndpoints" })
        ]
        //get the list of top courses by month of the instructor
        public async Task<ActionResult<List<ListTopCourseResponse>>> GetListTopCourseAsync(int month, int year, CancellationToken cancellationToken)
        {
            //get id usser
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var id = Guid.Parse(userId);

            var items = (await _earningServices.GetAllEarningAsync(month, year, id))
                .GroupBy(p => p.CourseId)
                .Select(g => new ListTopCourseResponse
                {
                    Title = g.Select(x => x.Course.Title).SingleOrDefault(),
                    Count = g.Count(),
                    Price = g.Sum(x => x.Price),
                });
            return Ok(items);
        }
    }
}
