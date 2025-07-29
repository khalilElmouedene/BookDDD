using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Queries.GetCommentList
{
    public class GetCommentViewModel
    {
        public int Id { get; private set; }

        public string Comment { get; private set; }
        public int PostId { get; private set; }
        public int MembreId { get; private set; }
    }
}