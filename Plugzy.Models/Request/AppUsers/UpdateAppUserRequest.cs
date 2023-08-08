namespace Plugzy.Models.Request.AppUsers;

public record UpdateAppUserRequest(string phoneNumber, string email, string name, int status, int type);
