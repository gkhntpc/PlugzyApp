using MediatR;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.AuthService.Commands
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
            public async Task<CommandResult<AuthResponse>> Handle(AuthCommand request, CancellationToken cancellation)
            {
                var returnModel = new AuthResponse() { AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI2MjM2NTEyYS04YmJjLTQ5MDUtYTZhNC0xODMwNDlkOWMxZDciLCJ1bmlxdWVfbmFtZSI6IjU0NTUzNDkzNjgiLCJDdXN0b21lcklkIjoiIiwiYWNjb3VudFR5cGUiOiJTeXN0ZW1Vc2VyIiwicm9sZSI6IlN5c3RlbVVzZXIiLCJuYmYiOjE2NTI4NjQxMTAsImV4cCI6MTY1Mjg4MjExMCwiaWF0IjoxNjUyODY0MTEwLCJpc3MiOiJpa2luY2lZZW5pIiwiYXVkIjoiUHVibGljIn0.ELAHHt8UPgSP2A1KGw-hn0UVWLfYyzfR3U64Gct7Dpo", RefreshToken = "4ppanSOXYpzDSQL7z8WGnVaOMy7GshwQ9gaKnZafhR5HCAqpvw/KIoFt130mY6Cxt3iPVd/q/xsfcUTeFA3thw==" };
                if (request.Model.PhoneNumber.Equals("905327080402") && request.Model.Code == 1234)
                {
                    returnModel.Type = Models.Response.Type.Login;
                    return CommandResult<AuthResponse>.GetSucceed("Başarı İle Giriş Yapıldı",returnModel);
                }
                else if (request.Model.Code == 1234)
                {
                    returnModel.Type = Models.Response.Type.Register;
                    return CommandResult<AuthResponse>.GetSucceed("Başarı İle Kayıt Olundu", returnModel);
                }
                return CommandResult<AuthResponse>.GetFailed("Otp Kodunuz Hatalı");

            }
        }
    }
}
