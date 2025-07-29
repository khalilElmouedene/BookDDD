using AutoMapper;
using BookDDD.Application.Contracts;
using BookDDD.Application.Wrapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Queries.GetCommentList
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, PaginatedResult<GetCommentViewModel>>
    {
        private readonly IRepository<KavaabookDDD.Core.Entities.Comments> _readRepository;
        private readonly IMapper _mapper;

        public GetCommentQueryHandler(IRepository<KavaabookDDD.Core.Entities.Comments> readRepository, IMapper mapper)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public async Task<PaginatedResult<GetCommentViewModel>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await _readRepository.GetPagedResponseAsync(request.PageNumber,request.PageSize);
            return _mapper.Map<PaginatedResult<GetCommentViewModel>>(comment);
        }
    }
}