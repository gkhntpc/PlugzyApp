namespace Plugzy.Models.Request.Authorization;

public record AuthorizationRequest(string phoneNumber, string otpCode);
