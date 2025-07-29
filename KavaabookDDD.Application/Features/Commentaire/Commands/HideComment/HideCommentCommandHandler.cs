using AutoMapper;

using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Commands.HideComment
{
    public class HideCommentCommandHandler : IRequestHandler<HideCommentCommand, int>
    {
        private readonly IRepository<Comments> _repository;
        private readonly IMapper _mapper;

        public HideCommentCommandHandler(IRepository<Comments> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(HideCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.CommanetId);
            comment.HideComment(comment.Id);
            await _repository.UpdateAsync(comment);
            return comment.Id;
        }
    }
}