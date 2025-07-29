
using BookDDD.Application.Features.Posts.Commands.CreatePost;
using BookDDD.Application.Features.Posts.Commands.CreateReact;
using BookDDD.Application.Features.Posts.Commands.DeletePost;
using BookDDD.Application.Features.Posts.Commands.HidePost;
using BookDDD.Application.Features.Posts.Commands.SignalPost;
using BookDDD.Application.Features.Posts.Commands.UpdatePost;
using BookDDD.Application.Features.Posts.Queries.GetAllPost;
using BookDDD.Application.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookDDD.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;


        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PaginatedResult<GetAllPostDto>>> GetAllPost([FromQuery] GetAllPostQuery query)
        {
            var list = await _mediator.Send(query);
            return Ok(list);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<int>> Create([FromBody] CreatePostCommand post)
        {
            var crt = await _mediator.Send(post);
            return Ok(crt);
        } 
        
        [HttpPost]
        [Route("React")]
        public async Task<ActionResult<int>> React([FromBody] ReactPostCommand post)
        {
            var crt = await _mediator.Send(post);
            return Ok(crt);
        }

        [HttpPost]
        [Route("Signal")]
        public async Task<ActionResult<string>> Signal([FromBody] SignalPostCommand post)
        {
            var crt = await _mediator.Send(post);
            return Ok(crt);
        }


        [HttpPut(Name = "UpdatePost")]
        public async Task<ActionResult<string>> Update([FromBody] UpdatePostCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var deletePostCommand = new DeletePostCommand() { Id = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }  
        
        [HttpPost]
        [Route("HidePost")]
        public async Task<ActionResult<string>> HidePost(int id)
        {
            var hidePostCommand = new HidePostCommand() { Id = id };
            var hide = await _mediator.Send(hidePostCommand);
            return Ok(hide);
        }
    }
}
