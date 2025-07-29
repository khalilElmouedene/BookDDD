using BookDDD.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Core.Entities.ObjectValue
{
    public class CommentSignal : BaseEntity<int>
    {
        public string Reason { get; private set; }
        public int CommentsId { get; private set; }
        public int MembreId { get; private set; }
        public virtual  Membre MembreOwnerComment { get; private set; }
        public int MembreSignalId { get; private set; }
        public virtual Membre MembreSignalComment { get; private set; }

        public CommentSignal(string reason, int commentsId, int membreId, int membreSignalId)
        {
            Reason = reason;
            CommentsId = commentsId;
            MembreId = membreId;
            MembreSignalId = membreSignalId;
        }
    }
}
