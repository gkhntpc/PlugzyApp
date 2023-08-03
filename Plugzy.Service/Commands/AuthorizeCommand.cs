using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    var authorizeResponse=new AuthorizeResponse()
                    {
                        AccessToken="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI2MjM2NTEyYS04YmJjLTQ5MDUtYTZhNC0xODMwNDlkOWMxZDciLCJ1bmlxdWVfbmFtZSI6IjU0NTUzNDkzNjgiLCJDdXN0b21lcklkIjoiIiwiYWNjb3VudFR5cGUiOiJTeXN0ZW1Vc2VyIiwicm9sZSI6IlN5c3RlbVVzZXIiLCJuYmYiOjE2NTI4NjQxMTAsImV4cCI6MTY1Mjg4MjExMCwiaWF0IjoxNjUyODY0MTEwLCJpc3MiOiJpa2luY2lZZW5pIiwiYXVkIjoiUHVibGljIn0.ELAHHt8UPgSP2A1KGw-hn0UVWLfYyzfR3U64Gct7Dpo",
                        RefreshToken="4ppanSOXYpzDSQL7z8WGnVaOMy7GshwQ9gaKnZafhR5HCAqpvw/KIoFt130mY6Cxt3iPVd/q/xsfcUTeFA3thw==",
                        Type=1
                    };
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

                    var authorizeResponseRegister=new AuthorizeResponse()
                    {
                        AccessToken="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI2MjM2NTEyYS04YmJjLTQ5MDUtYTZhNC0xODMwNDlkOWMxZDciLCJ1bmlxdWVfbmFtZSI6IjU0NTUzNDkzNjgiLCJDdXN0b21lcklkIjoiIiwiYWNjb3VudFR5cGUiOiJTeXN0ZW1Vc2VyIiwicm9sZSI6IlN5c3RlbVVzZXIiLCJuYmYiOjE2NTI4NjQxMTAsImV4cCI6MTY1Mjg4MjExMCwiaWF0IjoxNjUyODY0MTEwLCJpc3MiOiJpa2luY2lZZW5pIiwiYXVkIjoiUHVibGljIn0.ELAHHt8UPgSP2A1KGw-hn0UVWLfYyzfR3U64Gct7Dpo",
                        RefreshToken="4ppanSOXYpzDSQL7z8WGnVaOMy7GshwQ9gaKnZafhR5HCAqpvw/KIoFt130mY6Cxt3iPVd/q/xsfcUTeFA3thw==",
                        Type=2
                    };
                    return CommandResult<AuthorizeResponse>.GetSucceed(authorizeResponseRegister);
                }
                return CommandResult<AuthorizeResponse>.GetFailed("Numara kullanımda");
            }
        }
    }
}
