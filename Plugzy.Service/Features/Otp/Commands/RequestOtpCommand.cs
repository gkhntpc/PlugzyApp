using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Repositories.Contracts;
using Plugzy.Models.Base;
using Plugzy.Models.Request.Otp;
using Plugzy.Models.Response.Otp;
using Plugzy.Utilities.Constants.Message;

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
        private readonly IOtpRepository _otpRepository;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public Handler(IOtpRepository otpRepository, UserManager<User> userManager, IConfiguration configuration)
        {
            _otpRepository = otpRepository;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<CommandResult<OtpResponse>> Handle(RequestOtpCommand request, CancellationToken cancellationToken)
        {

            List<Domain.Entities.Otp> otpList = await _otpRepository.GetListAsync(x =>
                x.Phone == request.OtpRequest.phoneNumber &&
                x.IsActive == true);

            Domain.Entities.Otp? lastOtp = null;

            foreach (var oldOtp in otpList)
            {
                if (oldOtp.IsActive && oldOtp.Attempts >= 3 &&
                    DateTime.Compare((DateTime)oldOtp.UpdatedAt!.Value.AddMinutes(int.Parse(_configuration["OtpOptions:BlockForMinutes"]!)), DateTime.Now) > 0)
                {
                    lastOtp = oldOtp;
                }
                else if (oldOtp.IsActive)
                {
                    oldOtp.IsActive = false;
                    await _otpRepository.UpdateAsync(oldOtp);
                }
            }

            if (lastOtp is not null)
                return CommandResult<OtpResponse>.GetFailed(AuthorizationMessageConstants.TooMuchTry);

            int generatedOtp = Random.Shared.Next(1000, 10000);
            User user = await _userManager.FindByNameAsync(request.OtpRequest.phoneNumber);


            Domain.Entities.Otp createdOtp = new()
            {
                Code = generatedOtp.ToString(),
                ValidTill = DateTime.Now.AddSeconds(int.Parse(_configuration["OtpOptions:ValidForSeconds"]!)),
                Phone = request.OtpRequest.phoneNumber,
                Attempts = 0,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            OtpResponse response = new()
            {
                Seconds = int.Parse(_configuration["OtpOptions:ValidForSeconds"]!),
                Confirm = false,
                Code = generatedOtp
            };

            await _otpRepository.AddAsync(createdOtp);
            return CommandResult<OtpResponse>.GetSucceed(OtpMessageConstants.CreatedOtp, response);
        }
    }
}
