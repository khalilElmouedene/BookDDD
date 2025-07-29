using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Commands.SignalComment
{
    public class SignalCommentCommand : IRequest<int>
    {
        public string Reason { get; set; }
        public int CommentsId { get; set; }
        public int MembreSignalId { get; set; }
    }
}