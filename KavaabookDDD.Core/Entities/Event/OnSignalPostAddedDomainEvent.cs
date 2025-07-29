using BookDDD.Core.Entities.ObjectValue;
using System;
using BookDDD.Core.Base;

namespace BookDDD.Core.Entities.Event
{
    public class OnSignalPostAddedDomainEvent : BaseDomainEvent
    {
        public OnSignalPostAddedDomainEvent(PostSignal postSignal)
        {
            PostSignal = postSignal;
        }
        public PostSignal PostSignal { get; set; }
    }
}
