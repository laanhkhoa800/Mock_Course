using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository _repository;
        public NotificationService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Notification> CreateNotification(Notification notification)
        {
            var NewItem = await _repository.AddAsync(notification);
            return NewItem;
        }

        public async Task<List<Notification>> GetAllNotificationById(Guid userId)
        {
            var getById = new NotificationSpecification(userId);
            var items = await _repository.ListAsync(getById);
            return items;
        }

        public async Task<Notification> GetNotificationById(Guid id)
        {
            return await _repository.GetByIdAsync<Notification>(id);
        }

        public async Task<Notification> ReadNotification(Notification notification)
        {
            notification.IsRead = true;
            await _repository.UpdateAsync(notification);
            return notification;
        }
    }
}
