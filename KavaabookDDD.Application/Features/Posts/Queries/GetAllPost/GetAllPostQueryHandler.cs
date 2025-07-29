
using AutoMapper;
using BookDDD.Application.Contracts;
using BookDDD.Application.Wrapper;
using BookDDD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Posts.Queries.GetAllPost
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, PaginatedResult<GetAllPostDto>>
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public GetAllPostQueryHandler(
            IRepository<Post> repository, IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetAllPostDto>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            var list = await _repository.GetPagedResponseAsync(request.PageNumber, request.PageSize);
            return _mapper.Map<PaginatedResult<GetAllPostDto>>(list);
        }
    }
}
