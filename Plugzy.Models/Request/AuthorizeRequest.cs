namespace Plugzy.Models.Request
{
    public record AuthorizeRequest(string PhoneNumber, int OtpCode);
}
