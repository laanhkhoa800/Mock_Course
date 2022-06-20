using MediatR;
using System;

namespace FA.LegalHCM.SharedKernel
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}