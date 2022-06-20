using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Notifications
{
    [Authorize]
    public class List : BaseAsyncEndpoint<List<NotificationResponse>>
    {
        private readonly INotificationService _notificationService;
        public List(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        /// <summary>
        /// Get all account notifications when UserId matches accountId and has isDelete status equal to false
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("/notification")]
        [SwaggerOperation(
            Summary = "Gets a list of notification by userID",
            Description = "Gets a list of notification",
            OperationId = "Notification.List",
            Tags = new[] { "NotificationEndpoints" })
        ]
        public override  async Task<ActionResult<List<NotificationResponse>>> HandleAsync(CancellationToken cancellationToken)
        {
          
            var items = (await _notificationService.GetAllNotificationById(GetLoggedUserId()))
               .Select(item => new NotificationResponse
               {
                   Id = item.Id,
                   Title = item.Title,
                   CreateAt = item.CreateAt
               });

            return Ok(items);
        }
  
        Guid GetLoggedUserId()
        {
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var id = Guid.Parse(userId);
            return id;
        }
    }
}
