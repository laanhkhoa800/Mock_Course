using Ardalis.ApiEndpoints;
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
    public class Detail : BaseAsyncEndpoint<Guid, NotificationResponse>
    {
        private readonly INotificationService _notificationService;
        public Detail(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// when viewing the message details, will display the message according to the message id found with the form response
        /// and change the status isRead of the message to read (true)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("/notification/{id}")]
        [SwaggerOperation(
            Summary = "Gets a single notification",
            Description = "Gets a single notification by Id",
            OperationId = "Notification.Detail",
            Tags = new[] { "NotificationEndpoints" })
        ]
        public override async Task<ActionResult<NotificationResponse>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await _notificationService.GetNotificationById(id);

            var response = new NotificationResponse
            {
                Id = item.Id,
                Title = item.Title,
                Detail = item.Detail,
                CreateAt = item.CreateAt,
            };
            return Ok(_notificationService.ReadNotification(item));
        }
    }
}
