using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Notifications
{
    public class Create : BaseAsyncEndpoint<NewNotification, NotificationResponse
>
    {
        private readonly INotificationService _notificationService;
        public Create(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Add message with UserID as recipient's Id
        /// Student: will send the Id instructor of the registered course,
        /// Instructor: will send the user Id included in that course,
        /// Admin : will send to specific constructor Id retrieved by name via GetByID API,
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("/AddNotification")]
        [SwaggerOperation(
            Summary = "Creates a new Notification",
            Description = "Creates a new Notification",
            OperationId = "Notification.Create",
            Tags = new[] { "NotificationEndpoints" })
        ]
        public override async Task<ActionResult<NotificationResponse>> HandleAsync(NewNotification request, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var item = new Notification
                {
                    UserId = request.UserId,
                    Detail = request.Detail,
                    Title = request.Title,
                    CreateAt = DateTime.Now
                };
                var createdItem = await _notificationService.CreateNotification(item);
                return Ok(createdItem);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
