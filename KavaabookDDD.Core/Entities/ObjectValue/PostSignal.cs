using BookDDD.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Core.Entities.ObjectValue
{
    public class PostSignal : BaseEntity<int>
    {
        public string Reason { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public virtual Membre Membre { get; set; }
        public int MembreId { get; set; }
        public virtual Membre MembreSignal { get; set; }
        public int MembreSignalId { get; set; }


        private PostSignal()
        {

        }
        public PostSignal(string reason, int postId, int membreId,int membreSignalId)
        {
            Reason = reason;
            PostId = postId;
            MembreId = membreId;
            MembreSignalId = membreSignalId;
        }
    }

}
