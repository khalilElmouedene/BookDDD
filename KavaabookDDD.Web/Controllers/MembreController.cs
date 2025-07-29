using BookDDD.Application.Features.Membre.Commands.CreateMembre;
using BookDDD.Application.Features.Membre.Commands.Desactiver;
using BookDDD.Application.Features.Membre.Commands.SignalMembre;
using BookDDD.Application.Features.Membre.Commands.UpdateMembre;
using BookDDD.Application.Features.Membre.Queries.GetMembre;
using BookDDD.Application.Features.Membre.Queries.GetMembreList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDDD.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetMembreLisViewModel>>> GetMembers()
        {
            var membre = await _mediator.Send(new GetMembreListQuery());
            return Ok(membre);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<GetMembreViewModel>> GetMemberById(int id)
        {
            var getMembreQuery = new GetMembreQuery() { Id = id };

            var membre = await _mediator.Send(getMembreQuery);
            return Ok(membre);
        }

        [HttpPost("AddMembre")]
        public async Task<ActionResult<int>> Create([FromBody] CreateMembreCommand createMembreCommand)
        {
            int id = await _mediator.Send(createMembreCommand);
            return Ok(id);
        }

        [HttpPut("UpdateMembre")]
        public async Task<ActionResult> Update([FromBody] UpdateMembreCommand updateMembreCommand)
        {
            await _mediator.Send(updateMembreCommand);
            return NoContent();
        }

        [HttpPost("Signal Membre")]
        public async Task<ActionResult<int>> SignalMembre([FromBody] SignalMembreCommand signalMembreCommand)
        {
            int id = await _mediator.Send(signalMembreCommand);
            return Ok(id);
        }

        [HttpPost("Disactiver Membre")]
        public async Task<ActionResult<int>> DisactiverMembre([FromBody] DesactiverMembreCommand desactiverMembreCommand)
        {
            int id = await _mediator.Send(desactiverMembreCommand);
            return Ok(id);
        }
    }
}