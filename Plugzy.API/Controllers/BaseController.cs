using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Plugzy.API.Controllers;

/// <Summary>
///     Base Controller with Mediator
/// </Summary>
[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    /// <Summary>
    ///     Base Controller with Mediator
    /// </Summary>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
    private IMediator? _mediator;

    /// <Summary>
    ///     AcceptLanguage Header Value
    /// </Summary>
    protected string? AcceptLanguage => Request.Headers["Accept-Language"];
    /// <Summary>
    ///     TenantId Header Value
    /// </Summary>
    protected string? TenantId => Request.Headers["X-Tenant-Id"];
    /// <Summary>
    ///     DeviceLocation Header Value
    /// </Summary>
    protected object? DeviceLocation => Request.Headers["Device-Location"];
}
