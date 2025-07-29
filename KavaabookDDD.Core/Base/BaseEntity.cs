using System;
using System.Collections.Generic;

namespace BookDDD.Core.Base
{
    public abstract class BaseEntity<TId>
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
        public DateTime DateCreate { get; set; } = DateTime.UtcNow;
        public TId Id { get; set; }
    }
}