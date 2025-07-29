using AutoMapper;
using BookDDD.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Queries.GetMembre
{
    public class GetMembreQueryHandler : IRequestHandler<GetMembreQuery, GetMembreViewModel>
    {
        private readonly IReadRepository<KavaabookDDD.Core.Entities.Membre> _readRepository;
        private readonly IMapper _mapper;

        public GetMembreQueryHandler(IReadRepository<KavaabookDDD.Core.Entities.Membre> readRepository, IMapper mapper)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public async Task<GetMembreViewModel> Handle(GetMembreQuery request, CancellationToken cancellationToken)
        {
            var membre = await _readRepository.GetByIdAsync(request.Id);

            return _mapper.Map<GetMembreViewModel>(membre);
        }
    }
}