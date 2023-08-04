using MediatR;

using Microsoft.AspNetCore.Identity;

using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Repositories.Contracts;
using Plugzy.Infrastructure.Services.JwtService;
using Plugzy.Models.Base;
using Plugzy.Models.Request.Authorization;
using Plugzy.Models.Response.Authorization;
using Plugzy.Utilities.Constants.Authorization;
using Plugzy.Utilities.Constants.Entity.User;
using Plugzy.Utilities.Constants.Message;

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
        private readonly UserManager<User> _userManager;
        private readonly IOtpRepository _otpRepository;
        private readonly IJwtService _jwtService;

        public Handler(UserManager<User> userManager, IOtpRepository otpRepository, IJwtService jwtService)
        {
            _userManager = userManager;
            _otpRepository = otpRepository;
            _jwtService = jwtService;
        }
        public async Task<CommandResult<AuthorizationResponse>> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
        {
            var response = new AuthorizationResponse();

            #region OtpValidation
            Domain.Entities.Otp? otp = await _otpRepository.GetAsync(x =>
                x.Phone == request.AuthorizationRequest.phoneNumber &&
                x.IsActive == true);

            if (otp is null)
            {
                return CommandResult<AuthorizationResponse>.GetFailed(AuthorizationMessageConstants.WrongOtp);
            }

            if (otp.Code != request.AuthorizationRequest.otpCode)
            {
                if (otp.Attempts >= 3)
                    return CommandResult<AuthorizationResponse>.GetFailed(AuthorizationMessageConstants.TooMuchTry);

                otp.Attempts += 1;
                otp.UpdatedAt = DateTime.Now;
                await _otpRepository.UpdateAsync(otp);

                return CommandResult<AuthorizationResponse>.GetFailed(AuthorizationMessageConstants.WrongOtp);
            }

            if (DateTime.Compare(otp.ValidTill, DateTime.Now) < 0)
                return CommandResult<AuthorizationResponse>.GetFailed(AuthorizationMessageConstants.LateOtp);
            #endregion

            User user = await _userManager.FindByNameAsync(request.AuthorizationRequest.phoneNumber);

            otp.IsActive = false;
            otp.LoginTime = DateTime.Now;
            await _otpRepository.UpdateAsync(otp);

            // Login user if found in database
            if (user is not null)
            {
                response.Type = (int)AuthorizationType.Login;
                response.AccessToken = _jwtService.CreateAccessToken(user);
                response.RefreshToken = await _jwtService.CreateAndRegisterRefreshToken(user, _userManager);

                user.LastLogin = DateTime.Now;
                await _userManager.UpdateAsync(user);

                return CommandResult<AuthorizationResponse>.GetSucceed(AuthorizationMessageConstants.SuccessLogin, response);
            }

            // Registering new user
            Guid userId = Guid.NewGuid();

            User userToCreate = new()
            {
                Id = userId,
                PhoneNumber = request.AuthorizationRequest.phoneNumber,
                UserName = request.AuthorizationRequest.phoneNumber,
                Type = (int)UserType.Client,
                CreatedBy = userId,
                LastLogin = DateTime.Now,
                CreatedAt = DateTime.Now
            };

            IdentityResult result = await _userManager.CreateAsync(userToCreate);

            if (result.Succeeded)
            {
                response.AccessToken = _jwtService.CreateAccessToken(userToCreate);
                response.RefreshToken = await _jwtService.CreateAndRegisterRefreshToken(userToCreate, _userManager);

                return CommandResult<AuthorizationResponse>.GetSucceed(AuthorizationMessageConstants.SuccessRegister, response);
            }

            return CommandResult<AuthorizationResponse>.GetFailed(AuthorizationMessageConstants.FailRegister);
        }
    }
}
