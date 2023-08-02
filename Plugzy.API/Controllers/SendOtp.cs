using Microsoft.AspNetCore.Mvc;

using Plugzy.Models.Request.Otp;
using Plugzy.Service.Features.Otp.Commands;

namespace Plugzy.API.Controllers;

///<Summary>
/// OTP Controller
///</Summary>
public class SendOtp : BaseController
{
    /// <Summary>
    ///     Create Otp Endpoint
    /// </Summary>
    [HttpPost]
    public async Task<IActionResult> CreateOtp([FromBody] OtpRequest otpRequest)
    {
        var result = await Mediator.Send(new RequestOtpCommand(otpRequest));
        return Ok(result);
    }
}
