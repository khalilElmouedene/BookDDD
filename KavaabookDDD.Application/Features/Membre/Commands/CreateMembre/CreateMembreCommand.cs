using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Commands.CreateMembre
{
    public class CreateMembreCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UrlPicture { get; set; }
    }
}