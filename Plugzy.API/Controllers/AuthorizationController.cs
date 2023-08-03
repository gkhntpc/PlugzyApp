using MediatR;

using Microsoft.AspNetCore.Mvc;

using Plugzy.Models.Request.Authorization;
using Plugzy.Models.Request.Otp;
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
    public async Task<IActionResult> Authorize([FromBody] AuthorizationRequest authorizationRequest)
    {
        var result = await _mediator.Send(new AuthorizeCommand(authorizationRequest));
        return Ok(result);
    }

    /// <Summary>
    ///     Create Otp Endpoint [HttpPost]
    /// </Summary>
    [HttpPost("sendOtp")]
    public async Task<IActionResult> CreateOtp([FromBody] OtpRequest otpRequest)
    {
        var result = await _mediator.Send(new RequestOtpCommand(otpRequest));
        return Ok(result);
    }
}
