using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface INotificationService 
    {
        Task<Notification> CreateNotification(Notification notification);
        Task<List<Notification>> GetAllNotificationById(Guid userId);
        Task<Notification> GetNotificationById(Guid id);
        Task<Notification> ReadNotification(Notification notification);
    }
}
