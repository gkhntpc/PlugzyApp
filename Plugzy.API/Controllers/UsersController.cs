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
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Authorize")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(CommandResult<AuthorizeResponse>))]
        public async Task<CommandResult<AuthorizeResponse>> Authorize([FromBody] AuthorizeRequest authorizeRequest)
        {
            return await _mediator.Send(new AuthorizeCommand(authorizeRequest));
        }
        [HttpPost("SendOtp")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<SendOtpResponse>))]
        public async Task<CommandResult<SendOtpResponse>> SendOtp([FromBody] SendOtpRequest otpRequest)
        {
            return await _mediator.Send(new SendOtpCommand(otpRequest));
        }

    }
}
