using MediatR;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;

namespace Plugzy.Service.Commands
{
    public class LoginCommand:CommandBase<CommandResult<LoginResponse>>
    {
        private LoginRequest Model { get; }

        public LoginCommand(LoginRequest model)
        {
            Model = model;
        }

        public class Handler : IRequestHandler<LoginCommand, CommandResult<LoginResponse>>
        {
            public async Task<CommandResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                if(request.Model.PhoneNumber == "905327080402" && request.Model.Code==1234)
                {
                    var loginResponse=new LoginResponse(){PhoneNumber=request.Model.PhoneNumber,OtpCode=request.Model.Code};
                    return CommandResult<LoginResponse>.GetSucceed(loginResponse);
                }
                return CommandResult<LoginResponse>.GetFailed("");
            }
        }
    }
}
