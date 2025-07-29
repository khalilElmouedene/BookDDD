using BookDDD.Application.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Queries.GetCommentList
{
    public class GetCommentQuery : IRequest<PaginatedResult<GetCommentViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}