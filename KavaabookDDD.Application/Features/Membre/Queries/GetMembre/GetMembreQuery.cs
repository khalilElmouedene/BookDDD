using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Queries.GetMembre
{
    public class GetMembreQuery : IRequest<GetMembreViewModel>
    {
        public int Id { get; set; }
    }
}