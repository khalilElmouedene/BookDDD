using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Commands.RemoveComment
{
    public class RemoveCommentCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}