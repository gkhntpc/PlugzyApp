namespace Plugzy.Models.Request.AppUsers;

public record CreateAppUserRequest(string phoneNumber, string email, string name, int status, int type);
