﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Commentaire.Commands.HideComment
{
    public class HideCommentCommand : IRequest<int>
    {
        public int CommanetId { get; set; }
    }
}