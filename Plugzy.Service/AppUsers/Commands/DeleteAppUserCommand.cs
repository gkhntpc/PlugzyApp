using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Identity;

using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Response.AppUsers;

namespace Plugzy.Service.AppUsers.Commands;

public class DeleteAppUserCommand : CommandBase<CommandResult<DeletedAppUserResponse>>
{
    public string Id { get; }

    public DeleteAppUserCommand(string id)
    {
        Id = id;
    }

    public class Handler : IRequestHandler<DeleteAppUserCommand, CommandResult<DeletedAppUserResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public Handler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CommandResult<DeletedAppUserResponse>> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUserToDelete = await _userManager.FindByIdAsync(request.Id);

            if (appUserToDelete is null)
                return CommandResult<DeletedAppUserResponse>.NotFound();

            appUserToDelete.Status = Status.Deleted;
            appUserToDelete.DeletedAt = DateTime.UtcNow.Ticks;

            await _userManager.UpdateAsync(appUserToDelete);

            return CommandResult<DeletedAppUserResponse>
                .GetSucceed(_mapper.Map<DeletedAppUserResponse>(appUserToDelete));
        }
    }
}
