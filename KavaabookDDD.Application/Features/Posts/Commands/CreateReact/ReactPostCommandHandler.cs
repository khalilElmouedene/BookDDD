using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using BookDDD.Core.Entities.Aggregat.Specification;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Posts.Commands.CreateReact
{
    public class ReactPostCommandHandler : IRequestHandler<ReactPostCommand>
    {
        private readonly IRepository<Post> _repository;

        public ReactPostCommandHandler(IRepository<Post> repository)
        {
            _repository = repository;
        }


        public async Task<Unit> Handle(ReactPostCommand request, CancellationToken cancellationToken)
        {
            var spec = new PostByIdWithReactsSpec(request.PostId);
            var reactPost = await _repository.GetBySpecAsync(spec);
            reactPost.DisReact(request.PostId, request.MembreId, request.TypeReact, reactPost.Reacts.FirstOrDefault(x => x.MembreId == request.MembreId));
            await _repository.UpdateAsync(reactPost);
            return Unit.Value;
        }
    }
}
