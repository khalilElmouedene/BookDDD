using BookDDD.Core.Entities.Admin;
using BookDDD.Core.Entities.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDDD.Core.Base;

namespace BookDDD.Core.Entities.Event
{
    public class OnCommentSignalAddedDomainEvent : BaseDomainEvent
    {
        public OnCommentSignalAddedDomainEvent(CommentSignal commentSignal)
        {
            commentSignal = CommentSignal;
        }
        public CommentSignal CommentSignal { get; set; }
    }
}
