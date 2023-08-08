using MediatR;

using Microsoft.AspNetCore.Mvc;

using Plugzy.Models.Base;
using Plugzy.Models.Request.AppUsers;
using Plugzy.Models.Response.AppUsers;
using Plugzy.Service.AppUsers.Commands;
using Plugzy.Service.AppUsers.Queries;

namespace Plugzy.API.Controllers;

///<Summary>
/// User Controller
///</Summary>
[ApiController]
[Route("[controller]")]
public class UserController
{
    private readonly IMediator _mediator;

    ///<Summary>
    /// Getting Mediator via Constructor from DI
    ///</Summary>
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    ///<Summary>
    /// Create User Endpoint [HttpPost]
    ///</Summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<CreatedAppUserResponse>))]
    public async Task<CommandResult<CreatedAppUserResponse>> CreateAppUser([FromBody] CreateAppUserRequest request)
    {
        return await _mediator.Send(new CreateAppUserCommand(request)); ;
    }

    ///<Summary>
    /// Get User By Id Endpoint [HttpGet("{id}")]
    ///</Summary>
    [HttpGet("{id}")]
    public async Task<CommandResult<GetAppUserByIdResponse>> GetAppUserById([FromRoute] string id)
    {
        return await _mediator.Send(new GetAppUserByIdQuery(id));
    }

    ///<Summary>
    /// Get User List Endpoint [HttpPost]
    ///</Summary>
    [HttpPost("userList")]
    public async Task<CommandResult<AppUserListModel>> GetAppUserList([FromBody] GetAppUserListRequest request)
    {
        return await _mediator.Send(new GetAppUserListQuery(request));
    }

    ///<Summary>
    /// Update User Endpoint [HttpPut("{id}")]
    ///</Summary>
    [HttpPut("{id}")]
    public async Task<CommandResult<UpdatedAppUserResponse>> UpdateAppUser([FromRoute] string id, [FromBody] UpdateAppUserRequest request)
    {
        return await _mediator.Send(new UpdateAppUserCommand(id, request));
    }

    ///<Summary>
    /// Delete User Endpoint [HttpDelete("{id}")]
    ///</Summary>
    [HttpDelete("{id}")]
    public async Task<CommandResult<DeletedAppUserResponse>> DeleteAppUser([FromRoute] string id)
    {
        return await _mediator.Send(new DeleteAppUserCommand(id));
    }
}
