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

namespace BookDDD.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IRepository<Post> _repository;

        public CreatePostCommandHandler(
            IRepository<Post> repository
            )
        {
            _repository = repository;
        }


        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var newPost = new Post(request.Content, request.UrlsImg, request.MembreId, false);
            await _repository.AddAsync(newPost);
            return newPost.Id;
        }

    }
}
