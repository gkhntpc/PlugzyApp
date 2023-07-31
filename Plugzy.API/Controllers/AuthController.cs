using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Service.AuthService.Commands;


namespace Plugzy.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("Authorize")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<AuthResponse>))]
        public async Task<CommandResult<AuthResponse>> Authorize([FromBody] AuthorizeRequest request)
        {
            var response = await _mediator.Send(new AuthCommand(request));
            return response;
        }
        [HttpPost]
        [Route("SendOtp")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<OtpResponse>))]
        public async Task<CommandResult<OtpResponse>> SendOtp([FromBody] OtpRequest request)
        {
            var response = await _mediator.Send(new SendOtpCommand(request));
            return response;
        }
    }
}
