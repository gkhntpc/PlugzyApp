using Microsoft.AspNetCore.Mvc;

using Plugzy.Models.Request.Authorization;
using Plugzy.Service.Features.Authorization.Commands;

namespace Plugzy.API.Controllers;

///<Summary>
/// Authorization Controller
///</Summary>
public class AuthorizeController : BaseController
{
    ///<Summary>
    /// Authorization Endpoint [HttpPost]
    ///</Summary>
    [HttpPost]
    public async Task<IActionResult> Authorize([FromBody] AuthorizationRequest authorizationRequest)
    {
        var result = await Mediator.Send(new AuthorizeCommand(authorizationRequest));
        return Ok(result);
    }
}
