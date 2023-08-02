using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Plugzy.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    private IMediator _mediator;

    protected string? AcceptLanguage => Request.Headers["Accept-Language"];
    protected string? TenantId => Request.Headers["X-Tenant-Id"];
    protected object? DeviceLocation => Request.Headers["Device-Location"];
}
