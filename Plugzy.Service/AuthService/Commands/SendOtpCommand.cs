using MediatR;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.AuthService.Commands
{
    public class SendOtpCommand:CommandBase<CommandResult<OtpResponse>>
    {
        private OtpRequest Model { get; }
        public SendOtpCommand(OtpRequest model):base()
        {
            Model = model;
        }
        public class Handler : IRequestHandler<SendOtpCommand, CommandResult<OtpResponse>>
        {
            public async Task<CommandResult<OtpResponse>> Handle(SendOtpCommand request,CancellationToken cancellationToken)
            {
                if(request.Model.ClientKey.Equals("hfktdtrtsrseaeaeae")&&request.Model.Phone.Equals("905327080402"))
                {
                    var returnModel = new OtpResponse() { Confirm = true,Seconds=180 };
                    return CommandResult<OtpResponse>.GetSucceed("Başarı ile OTP gönderildi", returnModel);
                }
                return CommandResult<OtpResponse>.GetFailed("Başarısız İstek");
            }
        }
    }
}
