using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Posts.Commands.SignalPost
{
    public class SignalPostCommand : IRequest<string>
    {
        public int MembreId { get; set; }
        public int PostId { get; set; }
        public int MembreSignalId { get; set; }
        public string Reason { get; set; }
    }
}
