using MediatR;

namespace BookDDD.Application.Features.Commentaire.Commands.UpdateComment
{
    public class UpdateCommentCommand : IRequest
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int PostId { get; set; }
        public int MembreId { get; set; }
    }
}