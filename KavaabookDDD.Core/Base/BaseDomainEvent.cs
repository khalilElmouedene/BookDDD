using MediatR;
using System;

namespace BookDDD.Core.Base
{
    public abstract class BaseDomainEvent : INotification
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
    }
}