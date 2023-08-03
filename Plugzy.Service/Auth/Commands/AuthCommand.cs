using MediatR;
using Microsoft.AspNetCore.Identity;
using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Infrastructure.Repository;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Service.Helpers;
using Plugzy.Service.Services;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.Auth.Commands
{
    public class AuthCommand : CommandBase<CommandResult<AuthResponse>>
    {
        private AuthorizeRequest Model { get; }

        public AuthCommand(AuthorizeRequest model) : base()
        {
            Model = model;

        }
        public class Handler : IRequestHandler<AuthCommand, CommandResult<AuthResponse>>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IAuthenticationService _authenticationService;
            private readonly IJwtHelper _jwtHelper;
            public Handler(UserManager<AppUser> userManager,IAuthenticationService authenticationService,IJwtHelper jwtHelper)
            {
                _userManager = userManager;
                _authenticationService = authenticationService;
                _jwtHelper = jwtHelper;
            }
            public async Task<CommandResult<AuthResponse>> Handle(AuthCommand request, CancellationToken cancellation)
            {
                var getCodeResult = await _authenticationService.CheckOtpCode(request.Model.PhoneNumber);
                if (getCodeResult.Data == null)
                {
                    return CommandResult<AuthResponse>.GetFailed(getCodeResult.Message);
                }
                if (getCodeResult.Data.Code != request.Model.Code || !getCodeResult.Data.isActive)
                {
                    return CommandResult<AuthResponse>.GetFailed(MessageConstans.WrongOtpCode);
                }
                var checkUserResult = await _userManager.FindByNameAsync(request.Model.PhoneNumber);
                if (checkUserResult != null)
                {
                    await _authenticationService.DisableOtpCode(getCodeResult.Data);
                    var returnModel = _jwtHelper.CreateToken(checkUserResult);
                    returnModel.Type = Models.Response.Type.Login;
                    return CommandResult<AuthResponse>.GetSucceed(MessageConstans.SuccessLogin, returnModel);
                }

                var newUser = new AppUser()
                {
                    PhoneNumber = request.Model.PhoneNumber,
                    Status = Status.Active,
                    Type = Domain.Entities.Type.Register,
                    CreatedAt = DateTime.UtcNow.Ticks,
                    UserName = request.Model.PhoneNumber
                };

                var createUserResult = await _userManager.CreateAsync(newUser);
                if (createUserResult != null)
                {
                    await _authenticationService.DisableOtpCode(getCodeResult.Data);
                    var returnModel = _jwtHelper.CreateToken(newUser);
                    returnModel.Type = Models.Response.Type.Register;
                    return CommandResult<AuthResponse>.GetSucceed(MessageConstans.SuccessRegister, returnModel);
                }

                return CommandResult<AuthResponse>.GetFailed(MessageConstans.WrongOtpCode);

            }
        }
    }
}
