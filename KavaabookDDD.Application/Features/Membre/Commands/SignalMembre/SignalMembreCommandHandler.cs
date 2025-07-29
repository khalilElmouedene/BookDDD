using AutoMapper;
using BookDDD.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Commands.SignalMembre
{
    public class SignalMembreCommandHandler : IRequestHandler<SignalMembreCommand, int>
    {
        private readonly IRepository<KavaabookDDD.Core.Entities.Membre> _repository;
        private readonly IMapper _mapper;

        public SignalMembreCommandHandler(IRepository<KavaabookDDD.Core.Entities.Membre> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(SignalMembreCommand request, CancellationToken cancellationToken)
        {
            var member = await _repository.GetByIdAsync(request.MembreSignaledId);
            member.SignalMembre(request.MembreSignaledId, request.MembreWhoSignalId, request.CommenterSignaler);

            await _repository.UpdateAsync(member);
            return member.Id;
        }
    }
}