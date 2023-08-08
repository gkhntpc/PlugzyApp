using MediatR;
using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Models.Base;
using Plugzy.Models.Request;
using Plugzy.Models.Response;
using Plugzy.Service.Services;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.Auth.Commands
{
    public class SendOtpCommand:CommandBase<CommandResult<OtpResponse>>
    {
        private OtpRequest Model { get; }
        public SendOtpCommand(OtpRequest model) : base()
        {
            Model = model;
        }
        public class Handler : IRequestHandler<SendOtpCommand, CommandResult<OtpResponse>>
        {
            private readonly IAuthenticationService _authenticationService;
            private readonly IGenericRepositoryAsync<Otp> _otpRepository;
            public Handler(IGenericRepositoryAsync<Otp> otpRepository,IAuthenticationService authenticationService)
            {
                _otpRepository = otpRepository;
                _authenticationService = authenticationService;
            }
            public async Task<CommandResult<OtpResponse>> Handle(SendOtpCommand request,CancellationToken cancellationToken)
            {
                var checkCode = await _authenticationService.CheckOtpCode(request.Model.Phone);

                if (checkCode.Data != null&&checkCode.Data.isActive) {
                    var returnModel = new OtpResponse() { Confirm = true,Code=checkCode.Data.Code, Seconds = (int)(checkCode.Data.ValidTill - DateTime.Now.Ticks)};
                    return CommandResult<OtpResponse>.GetSucceed(MessageConstans.CreatedOtpCode, returnModel);
                }

                Random otpCode = new Random();
                var newOtp = new Otp()
                {
                    Phone = request.Model.Phone,
                    Attmps = false,
                    Code = otpCode.Next(1000, 10000),
                    isActive = true,
                    ValidTill=DateTime.Now.AddSeconds(180).Ticks,
                };
                var response = await _otpRepository.CreateAsync(newOtp);

                if(response != null)
                {
                    var returnModel = new OtpResponse() { Confirm = true, Code = response.Code, Seconds = 180 };
                    return CommandResult<OtpResponse>.GetSucceed(MessageConstans.CreatedOtpCode, returnModel);
                }
                return CommandResult<OtpResponse>.GetFailed(MessageConstans.BadRequest);

            }
        }
    }
}
