using BookDDD.Application.Features.Commentaire.Commands.CreateComment;
using BookDDD.Application.Features.Commentaire.Commands.HideComment;
using BookDDD.Application.Features.Commentaire.Commands.RemoveComment;
using BookDDD.Application.Features.Commentaire.Commands.SignalComment;
using BookDDD.Application.Features.Commentaire.Commands.UpdateComment;
using BookDDD.Application.Features.Commentaire.Queries.GetCommentList;
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
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetCommentViewModel>>> GetComments([FromQuery] GetCommentQuery query)
        {
            var membre = await _mediator.Send(query);
            return Ok(membre);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<int>> Create([FromBody] CreateCommentCommand comment)
        {
            int id = await _mediator.Send(comment);
            return Ok(id);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] UpdateCommentCommand updateCommentCommand)
        {
            await _mediator.Send(updateCommentCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCommnt")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var deleteComment = new RemoveCommentCommand() { Id = id };
            await _mediator.Send(deleteComment);
            return NoContent();
        }

        [HttpPost("Signal Comment")]
        public async Task<ActionResult<int>> SignalComment([FromBody] SignalCommentCommand signalCommentCommand)
        {
            int id = await _mediator.Send(signalCommentCommand);
            return Ok(id);
        }

        [HttpPost("Disactiver Comment")]
        public async Task<ActionResult<int>> DisactiverCommant([FromBody] HideCommentCommand hideCommentCommand)
        {
            int id = await _mediator.Send(hideCommentCommand);
            return Ok(id);
        }
    }
}