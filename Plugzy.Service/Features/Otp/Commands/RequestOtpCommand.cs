using MediatR;

using Microsoft.Extensions.Configuration;

using Plugzy.Models.Base;
using Plugzy.Models.Request.Otp;
using Plugzy.Models.Response.Otp;

namespace Plugzy.Service.Features.Otp.Commands;

public class RequestOtpCommand : CommandBase<CommandResult<OtpResponse>>
{
    public OtpRequest OtpRequest;

    public RequestOtpCommand(OtpRequest otpRequest) : base()
    {
        OtpRequest = otpRequest;
    }

    public class Handler : IRequestHandler<RequestOtpCommand, CommandResult<OtpResponse>>
    {
        public async Task<CommandResult<OtpResponse>> Handle(RequestOtpCommand request, CancellationToken cancellationToken)
        {
            var response = new OtpResponse();
            int fakeSeconds = 180;
            bool fakeConfirm = true;

            response.Seconds = fakeSeconds;
            response.Confirm = fakeConfirm;
            response.Code = int.Parse(_configuration["FakeAuth:Otp"]!);
            return  CommandResult<OtpResponse>.GetSucceed("Başarı ile OTP gönderildi", response);
        }

        private readonly IConfiguration _configuration;

        public Handler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
