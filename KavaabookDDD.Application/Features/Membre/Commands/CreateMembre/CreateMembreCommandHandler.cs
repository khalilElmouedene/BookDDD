using AutoMapper;
using BookDDD.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Commands.CreateMembre
{
    public class CreateMembreCommandHandler : IRequestHandler<CreateMembreCommand, int>
    {
        private readonly IRepository<KavaabookDDD.Core.Entities.Membre> _repository;
        private readonly IMapper _mapper;

        public CreateMembreCommandHandler(IRepository<KavaabookDDD.Core.Entities.Membre> repository,
            IMapper mapper

            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMembreCommand request, CancellationToken cancellationToken)
        {
            var member = new KavaabookDDD.Core.Entities.Membre(request.FullName, request.BirthDate, request.UrlPicture);
            await _repository.AddAsync(member);
            return member.Id;
        }
    }
}