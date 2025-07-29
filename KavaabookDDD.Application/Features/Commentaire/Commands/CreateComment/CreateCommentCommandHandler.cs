using AutoMapper;
using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Commands.CreateComment
{
    internal class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IRepository<Comments> _repository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IRepository<Comments> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comments(request.Comment, request.MembreId, request.PostId);
            await _repository.AddAsync(comment);
            return comment.Id;
        }
    }
}