using MediatR;
using Microsoft.AspNetCore.Mvc;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Service.Commands;

namespace Plugzy.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
                private readonly IMediator _mediator;
        public AuthorizeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<AuthorizeResponse>))]
        public async Task<CommandResult<AuthorizeResponse>> Authorize([FromBody] AuthorizeRequest request)
        {
            return await _mediator.Send(new AuthorizeCommand(request));

        }
    }
}
