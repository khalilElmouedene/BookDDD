using Ardalis.Specification;
using System.Linq;

namespace BookDDD.Core.Entities.Aggregat.Specification
{
    public class PostByIdWithReactsSpec : Specification<Post>, ISingleResultSpecification
    {
        public PostByIdWithReactsSpec(int id)
        {
            Query
                .Where(s => s.Id == id).Include(p => p.Reacts);
        }
    }
}
