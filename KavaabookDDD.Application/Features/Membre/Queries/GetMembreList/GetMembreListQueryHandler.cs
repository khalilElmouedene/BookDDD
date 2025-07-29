using AutoMapper;
using BookDDD.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Queries.GetMembreList
{
    public class GetMembreListQueryHandler : IRequestHandler<GetMembreListQuery, List<GetMembreLisViewModel>>
    {
        private readonly IReadRepository<KavaabookDDD.Core.Entities.Membre> _readRepository;
        private readonly IMapper _mapper;

        public GetMembreListQueryHandler(IReadRepository<KavaabookDDD.Core.Entities.Membre> readRepository, IMapper mapper)
        {
            _mapper = mapper;
            _readRepository = readRepository;
        }

        public async Task<List<GetMembreLisViewModel>> Handle(GetMembreListQuery request, CancellationToken cancellationToken)
        {
            var allMembre = await _readRepository.ListAsync();
            return _mapper.Map<List<GetMembreLisViewModel>>(allMembre);
        }
    }
}