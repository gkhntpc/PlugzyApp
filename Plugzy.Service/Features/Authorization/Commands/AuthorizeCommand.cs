using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Services.JwtService;
using Plugzy.Models.Base;
using Plugzy.Models.Request.Authorization;
using Plugzy.Models.Response.Authorization;
using Plugzy.Utilities.Constants.Authorization;
using Plugzy.Utilities.Constants.Entity.User;

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
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public Handler(IConfiguration configuration, UserManager<User> userManager, IJwtService jwtService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _jwtService = jwtService;
        }
        public async Task<CommandResult<AuthorizationResponse>> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
        {
            var response = new AuthorizationResponse();

            string fakeOtp = _configuration["FakeAuth:Otp"]!;
            string fakeNumber = _configuration["FakeAuth:Phone"]!;

            // Fail if OTP Code is invalid
            if (request.AuthorizationRequest.otpCode != fakeOtp)
            {
                return CommandResult<AuthorizationResponse>.GetFailed("Hatalı OTP Kodu!");
            }

            User user = await _userManager.FindByNameAsync(request.AuthorizationRequest.phoneNumber);

            // Login user if found in database
            if (user is not null)
            {
                response.Type = (int)AuthorizationType.Login;
                response.AccessToken = _jwtService.CreateAccessToken(user);
                response.RefreshToken = await _jwtService.CreateAndRegisterRefreshToken(user, _userManager);

                return CommandResult<AuthorizationResponse>.GetSucceed("Başarı ile login olundu", response);
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
                CreatedAt = DateTime.Now
            };

            IdentityResult result = await _userManager.CreateAsync(userToCreate);

            if (result.Succeeded)
            {
                response.AccessToken = _jwtService.CreateAccessToken(userToCreate);
                response.RefreshToken = await _jwtService.CreateAndRegisterRefreshToken(userToCreate, _userManager);

                return CommandResult<AuthorizationResponse>.GetSucceed("Başarı ile register olundu", response);
            }
            else
            {
                return CommandResult<AuthorizationResponse>.GetFailed("Register başarısız");
            }
        }
    }
}
