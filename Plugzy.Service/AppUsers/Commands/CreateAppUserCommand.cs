using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Identity;

using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Request.AppUsers;
using Plugzy.Models.Response.AppUsers;

namespace Plugzy.Service.AppUsers.Commands;

public class CreateAppUserCommand : CommandBase<CommandResult<CreatedAppUserResponse>>
{
    public CreateAppUserRequest Model { get; }

    public CreateAppUserCommand(CreateAppUserRequest model)
    {
        Model = model;
    }

    public class Handler : IRequestHandler<CreateAppUserCommand, CommandResult<CreatedAppUserResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public Handler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CommandResult<CreatedAppUserResponse>> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser userToCreate = new()
            {
                PhoneNumber = request.Model.phoneNumber,
                Email = request.Model.email,
                FullName = request.Model.name,
                Status = (Status)request.Model.status,
                Type = (Domain.Entities.Type)request.Model.type,
                CreatedAt = DateTime.UtcNow.Ticks,
                UserName = request.Model.phoneNumber
            };

            await _userManager.CreateAsync(userToCreate);

            return CommandResult<CreatedAppUserResponse>
                .GetSucceed(_mapper.Map<CreatedAppUserResponse>(userToCreate));
        }
    }
}
