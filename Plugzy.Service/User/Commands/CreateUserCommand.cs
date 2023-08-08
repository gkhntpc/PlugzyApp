using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
    public class CreateUserCommand:CommandBase<CommandResult<UserResponse>>
    {
        private CreateUserRequest Model { get; }
        public CreateUserCommand(CreateUserRequest model)
        {
            Model = model;
        }
        public class Handler : IRequestHandler<CreateUserCommand, CommandResult<UserResponse>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IMapper _mapper;
            public Handler(UserManager<AppUser> userManager,IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<CommandResult<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var checkUserResult = await _userManager.FindByNameAsync(request.Model.PhoneNumber);
                if (checkUserResult is not null)
                {
                    return CommandResult<UserResponse>.GetFailed(MessageConstans.UserAlreadyExists);
                }
                var newUser = _mapper.Map<AppUser>(request.Model);
                newUser.CreatedAt= DateTime.UtcNow.Ticks;
                newUser.UserName = request.Model.PhoneNumber;
                newUser.Status = Status.Active;
                newUser.Type = Domain.Entities.Type.Register;


                var result = await _userManager.CreateAsync(newUser,request.Model.Password);
                if (result is not null) 
                {
                    var viewModel = _mapper.Map<UserResponse>(newUser);
                    return CommandResult<UserResponse>.GetSucceed("", viewModel);
                }
                return CommandResult<UserResponse>.GetFailed(MessageConstans.BadRequest);
            }
        }
    }
}
