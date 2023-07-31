namespace Plugzy.Models.Response
{
    public class AuthorizeResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public TypeEnum Type { get; set; }
    }
    public enum TypeEnum
    {
        Login=1, Register=2
    }
}
