using AutoMapper;
using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comments> _repository;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IRepository<Comments> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.Id);

            comment.Update(request.Comment);
            await _repository.UpdateAsync(comment);

            return Unit.Value;
        }
    }
}