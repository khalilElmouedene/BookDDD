using MediatR;

namespace BookDDD.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
