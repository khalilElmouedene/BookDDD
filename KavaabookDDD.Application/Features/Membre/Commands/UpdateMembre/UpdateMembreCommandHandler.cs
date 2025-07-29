using AutoMapper;
using BookDDD.Application.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Commands.UpdateMembre
{
    internal class UpdateMembreCommandHandler : IRequestHandler<UpdateMembreCommand>
    {
        private readonly IRepository<KavaabookDDD.Core.Entities.Membre> _repository;
        private readonly IMapper _mapper;

        public UpdateMembreCommandHandler(IRepository<KavaabookDDD.Core.Entities.Membre> repository,
            IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMembreCommand request, CancellationToken cancellationToken)
        {
            var membre = await _repository.GetByIdAsync(request.Id);
            membre.Update(request.FullName, request.BirthDate, request.UrlPicture);
            await _repository.UpdateAsync(membre);
            return Unit.Value;
        }
    }
}