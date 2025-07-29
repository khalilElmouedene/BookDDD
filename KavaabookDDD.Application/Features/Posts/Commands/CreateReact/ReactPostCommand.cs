using MediatR;

namespace BookDDD.Application.Features.Posts.Commands.CreateReact
{
    public class ReactPostCommand : IRequest
    {
        public int TypeReact { get; set; }
        public int MembreId { get; set; }
        public int PostId { get; set; }
    }
}
