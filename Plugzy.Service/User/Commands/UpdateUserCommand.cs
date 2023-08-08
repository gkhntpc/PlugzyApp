
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.User.Commands
{
    public class UpdateUserCommand:CommandBase<CommandResult<UserResponse>>
    {
        private UpdateUserRequest Model { get; }
        private Guid Id { get; }
        public UpdateUserCommand(UpdateUserRequest model, Guid id) : base()
        {
            Model = model;
            Id = id;
        }
        public class Handler : IRequestHandler<UpdateUserCommand,CommandResult<UserResponse>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IMapper _mapper;
            public Handler(UserManager<AppUser> userManager,IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }
            public async Task<CommandResult<UserResponse>> Handle(UpdateUserCommand request,CancellationToken cancellationToken)
            {
                var getUser = await _userManager.Users.Where(u => u.Id == request.Id).FirstOrDefaultAsync();
                if (getUser is null)
                {
                    return CommandResult<UserResponse>.GetFailed(MessageConstans.UserNotFound);
                }
                getUser.PhoneNumber = request.Model.PhoneNumber;
                getUser.FullName = request.Model.FullName;
                getUser.UpdatedAt= DateTime.UtcNow.Ticks;

                var result = await _userManager.UpdateAsync(getUser);
                if (result is not null)
                {
                    var viewModel = _mapper.Map<UserResponse>(getUser);
                    return CommandResult<UserResponse>.GetSucceed("", viewModel);
                }
                return CommandResult<UserResponse>.GetFailed(MessageConstans.BadRequest);
            }
        }
    }
}
