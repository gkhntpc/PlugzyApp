using Plugzy.Models.Response;

namespace Plugzy.Service.Helpers
{
    public static class JwtHelper
    {
        public static AuthorizeResponse Create(int type)
        {
            var authorizeResponse=new AuthorizeResponse()
            {
                AccessToken="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI2MjM2NTEyYS04YmJjLTQ5MDUtYTZhNC0xODMwNDlkOWMxZDciLCJ1bmlxdWVfbmFtZSI6IjU0NTUzNDkzNjgiLCJDdXN0b21lcklkIjoiIiwiYWNjb3VudFR5cGUiOiJTeXN0ZW1Vc2VyIiwicm9sZSI6IlN5c3RlbVVzZXIiLCJuYmYiOjE2NTI4NjQxMTAsImV4cCI6MTY1Mjg4MjExMCwiaWF0IjoxNjUyODY0MTEwLCJpc3MiOiJpa2luY2lZZW5pIiwiYXVkIjoiUHVibGljIn0.ELAHHt8UPgSP2A1KGw-hn0UVWLfYyzfR3U64Gct7Dpo",
                RefreshToken="4ppanSOXYpzDSQL7z8WGnVaOMy7GshwQ9gaKnZafhR5HCAqpvw/KIoFt130mY6Cxt3iPVd/q/xsfcUTeFA3thw==",
                Type=type
            };
            return authorizeResponse;
        }
    }
}
