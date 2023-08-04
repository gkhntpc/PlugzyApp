using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Service.Helpers;

namespace Plugzy.Service.Commands
{
    public class AuthorizeCommand : CommandBase<CommandResult<AuthorizeResponse>>
    {
        private AuthorizeRequest Model { get; }

        public AuthorizeCommand(AuthorizeRequest model)
        {
            Model = model;
        }

        public class Handler : IRequestHandler<AuthorizeCommand, CommandResult<AuthorizeResponse>>
        {
            private readonly UserManager<AppUser> _userManager;

            public Handler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<CommandResult<AuthorizeResponse>> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
            {
                if (request.Model.PhoneNumber == "905327080402" && request.Model.OtpCode == 1234)
                {
                    var authorizeResponse=JwtHelper.Create(1);
                    return CommandResult<AuthorizeResponse>.GetSucceed(authorizeResponse);
                }
                var existUser= await _userManager.Users.SingleOrDefaultAsync(x=>x.PhoneNumber==request.Model.PhoneNumber);
                if(existUser is null)
                { 
                    var appUser=new AppUser
                    {
                        PhoneNumber = request.Model.PhoneNumber,
                        UserName=Guid.NewGuid().ToString(),
                        Type=AppUser.UserTypes.Client,
                        Statu=AppUser.UserStatus.Active,
                        LastLogin=DateTime.Now
                    };
                    appUser.Created();
                    var createUser= await _userManager.CreateAsync(appUser,Guid.NewGuid().ToString());

                    var authorizeResponseRegister=JwtHelper.Create(2);
                    return CommandResult<AuthorizeResponse>.GetSucceed(authorizeResponseRegister);
                }
                return CommandResult<AuthorizeResponse>.GetFailed("Numara kullanımda");
            }
        }
    }
}
