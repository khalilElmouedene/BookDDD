using BookDDD.Core.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookDDD.Core.Entities.ObjectValue
{
    public class Reacts : BaseEntity<int>
    {
        public int TypeReact { get; private set; }
        public int MembreId { get; private set; }
        public virtual Post Post { get; private set; }
        public int PostId { get; private set; }

        private Reacts()
        {
        }

        public Reacts(int typeReact, int membreId, int postId)
        {
            TypeReact = typeReact;
            MembreId = membreId;
            PostId = postId;
        }
    }
}