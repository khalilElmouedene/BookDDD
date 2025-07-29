using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Commands.RemoveComment
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand, string>
    {
        private readonly IRepository<Comments> _repository;

        public RemoveCommentCommandHandler(IRepository<Comments> repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.Id);
            if (comment == null) throw new Exception("Aucune Element avec ce id");
            comment.DeleteComment(comment.Id, "Remove");
            await _repository.UpdateAsync(comment);
            return "Suppression avec success";
        }
    }
}