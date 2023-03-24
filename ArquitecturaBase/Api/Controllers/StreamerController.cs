using Application.Features.Streamers.Commands.CreateStreamer;
using Application.Features.Streamers.Commands.DeleteStreamer;
using Application.Features.Streamers.Commands.Queries.GetStreamerByName;
using Application.Features.Streamers.Commands.Queries.GetStreamerList;
using Application.Features.Streamers.Commands.UpdateStreamer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StreamerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StreamerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost(Name = "CreateStreamer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateStreamer([FromBody] CreateStreamerCommand command)
        {
            return await _mediator.Send(command);
        }

        [Authorize]
        [HttpPut(Name = "UpdateStreamer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateStreamer([FromBody] UpdateStreamerCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}", Name = "DeleteStreamer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteStreamer(int id)
        {
            await _mediator.Send(new DeleteStreamerCommand(id));

            return NoContent();
        }

        [Authorize]
        [HttpGet("{streamerName}", Name = "GetStreamer")]
        [ProducesResponseType(typeof(StreamersVM), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<StreamersVM>> GetStreamerByName(string streamerName)
        {
            var query = new GetStreamerByNameQuery(streamerName);
            var streamer = await _mediator.Send(query);
            return Ok(streamer);
        }

        [Authorize]
        [HttpGet(Name = "GetStreamers")]
        [ProducesResponseType(typeof(IEnumerable<StreamersVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StreamersVM>>> GetStreamers()
        {
            var query = new GetStreamerListQuery();
            var streamers = await _mediator.Send(query);
            return Ok(streamers);
        }
    }
}