using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Core.Entities.Aggregat.Specification
{
    public class PostByMembreIdSpec : Specification<Post>, ISingleResultSpecification
    {
        public PostByMembreIdSpec(int membreId)
        {
            Query
                .Where(i => i.MembreId == membreId);
        }
    }
}
