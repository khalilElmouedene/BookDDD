using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Application.Features.Membre.Queries.GetMembreList
{
    public class GetMembreListQuery : IRequest<List<GetMembreLisViewModel>>
    {
    }
}