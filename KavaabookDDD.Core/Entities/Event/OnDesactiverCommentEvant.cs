using BookDDD.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Core.Entities.Event
{
    public class OnDesactiverCommentEvant : BaseDomainEvent
    {
        public OnDesactiverCommentEvant(int commentId)
        {
            CommentId = commentId;
        }

        public int CommentId { get; set; }
    }
}