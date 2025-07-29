using MediatR;

namespace BookDDD.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
    }
}