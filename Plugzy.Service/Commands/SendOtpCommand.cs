using MediatR;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;

namespace Plugzy.Service.Commands
{
    public class SendOtpCommand:CommandBase<CommandResult<SendOtpResponse>>
    {
        public SendOtpRequest Model { get; }

        public SendOtpCommand(SendOtpRequest model)
        {
            Model = model;
        }
        public class Handler : IRequestHandler<SendOtpCommand, CommandResult<SendOtpResponse>>
        {
            public async Task<CommandResult<SendOtpResponse>> Handle(SendOtpCommand request, CancellationToken cancellationToken)
            {
                var response=new SendOtpResponse();
                
                if (request.Model.ClientKey== "hfktdtrtsrseaeaeae" && request.Model.Phone== "905327080402")
                { 
                    response.Confirm = true;
                    response.Seconds = 180;
                    return CommandResult<SendOtpResponse>.GetSucceed(response);
                }
                return CommandResult<SendOtpResponse>.GetFailed("otp fail");
            }
        }
    }
}
