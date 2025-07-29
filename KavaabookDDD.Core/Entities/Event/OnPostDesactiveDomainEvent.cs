using BookDDD.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Core.Entities.Event
{
    public class OnPostDesactiveDomainEvent : BaseDomainEvent
    {
        public OnPostDesactiveDomainEvent(int postId)
        {
            PostId = postId;
        }

        public int PostId  { get; set; }
    }
}
