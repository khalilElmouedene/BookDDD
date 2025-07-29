using BookDDD.Application.Wrapper;
using MediatR;

namespace BookDDD.Application.Features.Posts.Queries.GetAllPost
{
    public class GetAllPostQuery : IRequest<PaginatedResult<GetAllPostDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
