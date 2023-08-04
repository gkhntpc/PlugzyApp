using MediatR;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;

namespace Plugzy.Service.Commands
{
    public class SendOtpCommand:CommandBase<CommandResult<SendOtpResponse>>
    {
        private SendOtpRequest Model { get; }

        public SendOtpCommand(SendOtpRequest model)
        {
            Model = model;
        }
        public class Handler : IRequestHandler<SendOtpCommand, CommandResult<SendOtpResponse>>
        {
            public async Task<CommandResult<SendOtpResponse>> Handle(SendOtpCommand request, CancellationToken cancellationToken)
            {
                if(request.Model.ClientId== "hfktdtrtsrseaeaeae" && request.Model.PhoneNumber== "905327080402")
                {
                    var sendOtpResponse = new SendOtpResponse()
                    {
                        Confirm=true,
                        Seconds=180,
                        Code=1234
                    };
                    return CommandResult<SendOtpResponse>.GetSucceed(sendOtpResponse);
                }
                return CommandResult<SendOtpResponse>.GetFailed("Başarısız istek.");
            }
        }
    }
}
