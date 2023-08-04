namespace Plugzy.Models.Response
{
    public class AuthorizeResponse
    {
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public int Type { get; set; }
    }
}
