using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Posts.Commands.HidePost
{
    public class HidePostCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
