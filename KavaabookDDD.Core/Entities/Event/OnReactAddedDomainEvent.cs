using BookDDD.Core.Entities.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDDD.Core.Base;

namespace BookDDD.Core.Entities.Event
{
    public class OnReactAddedDomainEvent: BaseDomainEvent
    {
        public OnReactAddedDomainEvent(Reacts reacts)
        {
            Reacts = reacts;
        }
        public Reacts Reacts { get; set; }
    }
}
