using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Commands.SignalMembre
{
    public class SignalMembreCommand : IRequest<int>
    {
        public int MembreSignaledId { get; set; }
        public int MembreWhoSignalId { get; set; }
        public string CommenterSignaler { get; set; }
    }
}