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
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<LoginResponse>))]
        public async Task<CommandResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            return await _mediator.Send(new LoginCommand(loginRequest));
        }
        [HttpPost("SendOtp")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<SendOtpResponse>))]
        public async Task<CommandResult<SendOtpResponse>> SendOtp([FromBody] SendOtpRequest sendOtpRequest)
        {
            return await _mediator.Send(new SendOtpCommand(sendOtpRequest));
        }

    }
}
