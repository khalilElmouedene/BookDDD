using MediatR;

namespace BookDDD.Application.Features.Commentaire.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string Comment { get; set; }
        public int PostId { get; set; }
        public int MembreId { get; set; }
    }
}