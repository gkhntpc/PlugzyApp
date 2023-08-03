using MediatR;

using Microsoft.AspNetCore.Mvc;

using Plugzy.Models.Base;
using Plugzy.Models.Request.Authorization;
using Plugzy.Models.Request.Otp;
using Plugzy.Models.Response.Authorization;
using Plugzy.Models.Response.Otp;
using Plugzy.Service.Features.Authorization.Commands;
using Plugzy.Service.Features.Otp.Commands;

namespace Plugzy.API.Controllers;

///<Summary>
/// Authorization Controller
///</Summary>
public class AuthorizationController : BaseController
{
    ///<Summary>
    /// Authorization Controller Constructor with Mediator
    ///</Summary>
    public AuthorizationController(IMediator mediator) : base(mediator)
    {
    }

    ///<Summary>
    /// Authorization Endpoint [HttpPost]
    ///</Summary>
    [HttpPost("authorize")]
    public async Task<CommandResult<AuthorizationResponse>> Authorize([FromBody] AuthorizationRequest authorizationRequest)
    {
        return await _mediator.Send(new AuthorizeCommand(authorizationRequest));
    }

    /// <Summary>
    ///     Create Otp Endpoint [HttpPost]
    /// </Summary>
    [HttpPost("sendOtp")]
    public async Task<CommandResult<OtpResponse>> CreateOtp([FromBody] OtpRequest otpRequest)
    {
        return await _mediator.Send(new RequestOtpCommand(otpRequest));
    }
}
