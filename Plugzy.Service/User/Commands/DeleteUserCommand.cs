using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.User.Commands
{
    public class DeleteUserCommand : CommandBase<CommandResult<AppUser>>
    {
        private Guid Id { get; }
        public DeleteUserCommand(Guid id) : base()
        {
            Id = id;
        }
        public class Handler : IRequestHandler<DeleteUserCommand,CommandResult<AppUser>>
        {
            private readonly UserManager<AppUser> _userManager;
            public Handler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }
            public async Task<CommandResult<AppUser>> Handle(DeleteUserCommand request,CancellationToken cancellationToken)
            {
                var getUser = await _userManager.Users.Where(u => u.Id == request.Id).FirstOrDefaultAsync();
                if (getUser is null) 
                {
                    return CommandResult<AppUser>.GetFailed(MessageConstans.UserNotFound);
                }

                var result = await _userManager.DeleteAsync(getUser);
                if (result is not null) 
                {
                    return CommandResult<AppUser>.GetSucceed("",null);
                }
                return CommandResult<AppUser>.GetFailed(MessageConstans.BadRequest);

            }
        }

    }
}
