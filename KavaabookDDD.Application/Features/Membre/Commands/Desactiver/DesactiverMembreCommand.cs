using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Commands.Desactiver
{
    public class DesactiverMembreCommand : IRequest<int>
    {
        public int MemberId { get; set; }
    }
}