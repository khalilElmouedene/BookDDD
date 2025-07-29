using MediatR;
using System;

namespace BookDDD.Application.Features.Membre.Commands.UpdateMembre
{
    public class UpdateMembreCommand : IRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UrlPicture { get; set; }
    }
}