namespace Plugzy.Models.Response.Authorization;

public class AuthorizationResponse 
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int Type { get; set; }
}
