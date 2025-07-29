using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Posts.Commands.SignalPost
{
    public class SignalPostCommandHandler : IRequestHandler<SignalPostCommand, string>
    {

        private readonly IRepository<Post> _repository;

        public SignalPostCommandHandler(IRepository<Post> postRepository)
        {
            _repository = postRepository;
        }

        public async Task<string> Handle(SignalPostCommand request, CancellationToken cancellationToken)
        {
            var postSignal = await _repository.GetByIdAsync(request.PostId);

            postSignal.SignalPost(request.Reason, request.PostId, request.MembreId,request.MembreSignalId);

            await _repository.UpdateAsync(postSignal);

            return "Signal avec success";
        }
    }
}
