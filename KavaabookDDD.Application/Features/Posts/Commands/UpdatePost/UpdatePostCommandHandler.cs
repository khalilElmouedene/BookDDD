using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, string>
    {

        private readonly IRepository<Post> _postRepository;

        public UpdatePostCommandHandler(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<string> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var item = await _postRepository.GetByIdAsync(request.Id);
            if (item == null) throw new Exception("Aucune Element avec ce id");

            item.Update(request.Content, request.ImageUrl);
            await _postRepository.UpdateAsync(item);
            return "Modifier avec success";
        }
    }
}
