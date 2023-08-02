using MediatR;

using Plugzy.Models.Base;
using Plugzy.Models.Request.Authorization;
using Plugzy.Models.Response.Authorization;
using Plugzy.Utilities.Constants.Authorization;

namespace Plugzy.Service.Features.Authorization.Commands;

public class AuthorizeCommand : CommandBase<CommandResult<AuthorizationResponse>>
{
    public AuthorizationRequest AuthorizationRequest { get; }

    public AuthorizeCommand(AuthorizationRequest authorizationRequest)
    {
        AuthorizationRequest = authorizationRequest;
    }

    public class Handler : IRequestHandler<AuthorizeCommand, CommandResult<AuthorizationResponse>>
    {
        public async Task<CommandResult<AuthorizationResponse>> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
        {
            var response = new AuthorizationResponse();

            // validate otp, if true continue else fail result

            string fakeOtp = "1234";
            string fakeNumber = "905327080402";
            response.AccessToken = "fake access token";
            response.RefreshToken = "fake refresh token";

            if (request.AuthorizationRequest.otpCode != fakeOtp)
            {
                return CommandResult<AuthorizationResponse>.GetFailed("Hatalı OTP Kodu!");
            }

            if (request.AuthorizationRequest.phoneNumber == fakeNumber)
            {
                response.Type = AuthorizationType.Login;
                return CommandResult<AuthorizationResponse>.GetSucceed("Başarı ile login olundu", response);
            }
            // Success Register
            else
            {
                response.Type = AuthorizationType.Register;
                return CommandResult<AuthorizationResponse>.GetSucceed("Başarı ile kayıt olundu", response);
            }
        }
    }
}
