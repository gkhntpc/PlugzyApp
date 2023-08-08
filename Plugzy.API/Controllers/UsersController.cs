using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Service.Auth.Commands;
using Plugzy.Service.User.Commands;
using Plugzy.Service.User.Queries;

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

        [HttpGet]
        [Route("UserList")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<PagedResult<UserListResponse>>))]
        public async Task<CommandResult<PagedResult<UserListResponse>>> GetAllUserList([FromQuery]PaginationRequest request)
        {
            var response = await _mediator.Send(new GetAllUserQuery(request));
            return response;
        }
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<UserResponse>))]
        public async Task<CommandResult<UserResponse>> GetUserById(Guid Id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(Id));
            return response;
        }
        [HttpDelete]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<AppUser>))]
        public async Task<CommandResult<AppUser>> DeleteUser(Guid Id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(Id));
            return response;
        }
        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<UserResponse>))]
        public async Task<CommandResult<UserResponse>> UpdateUser(Guid Id, [FromBody]UpdateUserRequest request)
        {
            var response = await _mediator.Send(new UpdateUserCommand(request,Id));
            return response;
        }
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResult<UserResponse>))]
        public async Task<CommandResult<UserResponse>> CreateUser([FromBody]CreateUserRequest request)
        {
            var response = await _mediator.Send(new CreateUserCommand(request));
            return response;
        }
    }
}
