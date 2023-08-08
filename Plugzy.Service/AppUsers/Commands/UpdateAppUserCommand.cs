using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Identity;

using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Request.AppUsers;
using Plugzy.Models.Response.AppUsers;

namespace Plugzy.Service.AppUsers.Commands;

public class UpdateAppUserCommand : CommandBase<CommandResult<UpdatedAppUserResponse>>
{
    public string Id { get; }
    public UpdateAppUserRequest Model { get; }

    public UpdateAppUserCommand(string id, UpdateAppUserRequest model)
    {
        Id = id;
        Model = model;
    }

    public class Handler : IRequestHandler<UpdateAppUserCommand, CommandResult<UpdatedAppUserResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public Handler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CommandResult<UpdatedAppUserResponse>> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUserToUpdate = await _userManager.FindByIdAsync(request.Id);

            if (appUserToUpdate is null)
                return CommandResult<UpdatedAppUserResponse>.NotFound();

            appUserToUpdate.UpdatedAt = DateTime.UtcNow.Ticks;
            appUserToUpdate.UpdatedBy = Guid.Parse(request.Id);
            appUserToUpdate.PhoneNumber = request.Model.phoneNumber;
            appUserToUpdate.UserName = request.Model.phoneNumber;
            appUserToUpdate.Email = request.Model.email;
            appUserToUpdate.FullName = request.Model.name;
            appUserToUpdate.Status = (Status)request.Model.status;
            appUserToUpdate.Type = (Domain.Entities.Type)request.Model.type;

            await _userManager.UpdateAsync(appUserToUpdate);

            return CommandResult<UpdatedAppUserResponse>
                .GetSucceed(_mapper.Map<UpdatedAppUserResponse>(appUserToUpdate));
        }
    }
}
