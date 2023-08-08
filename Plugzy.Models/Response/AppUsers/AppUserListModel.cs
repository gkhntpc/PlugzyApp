using Plugzy.Models.Base;

namespace Plugzy.Models.Response.AppUsers;

public class AppUserListModel : BasePageableModel
{
    public IList<GetAppUserByIdResponse> UserList { get; set; }
}
