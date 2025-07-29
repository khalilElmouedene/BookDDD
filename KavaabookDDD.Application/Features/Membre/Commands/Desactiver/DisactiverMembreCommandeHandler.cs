using AutoMapper;
using BookDDD.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Commands.Desactiver
{
    public class DisactiverMembreCommandeHandler : IRequestHandler<DesactiverMembreCommand, int>
    {
        private readonly IRepository<KavaabookDDD.Core.Entities.Membre> _repository;
        private readonly IMapper _mapper;

        public DisactiverMembreCommandeHandler(IRepository<KavaabookDDD.Core.Entities.Membre> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(DesactiverMembreCommand request, CancellationToken cancellationToken)
        {
            var membre = await _repository.GetByIdAsync(request.MemberId);
            membre.Desactiver(request.MemberId);
            await _repository.UpdateAsync(membre);
            return membre.Id;
        }
    }
}