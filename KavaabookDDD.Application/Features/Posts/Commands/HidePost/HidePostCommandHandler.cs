using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Posts.Commands.HidePost
{
    public class HidePostCommandHandler : IRequestHandler<HidePostCommand, string>
    {
        private readonly IRepository<Post> _postRepository;

        public HidePostCommandHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<string> Handle(HidePostCommand request, CancellationToken cancellationToken)
        {
            var item = await _postRepository.GetByIdAsync(request.Id);
            if (item == null) throw new Exception("Aucune Element avec ce id");
            item.HidePost(item.Id);
            await _postRepository.UpdateAsync(item);
            return "Caché avec success";
        }
    }
}
