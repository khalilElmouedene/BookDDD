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

namespace BookDDD.Application.Features.Commentaire.Commands.SignalComment
{
    public class SignalCommnetCommandHandler : IRequestHandler<SignalCommentCommand, int>
    {
        private readonly IRepository<Comments> _repository;
        private readonly IMapper _mapper;

        public SignalCommnetCommandHandler(IRepository<Comments> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(SignalCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.CommentsId);
            comment.SignalComment(request.Reason, request.MembreSignalId);
            await _repository.UpdateAsync(comment);
            return comment.Id;
        }
    }
}