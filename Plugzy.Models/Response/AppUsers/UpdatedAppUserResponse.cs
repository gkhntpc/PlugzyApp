namespace Plugzy.Models.Response.AppUsers;

public class UpdatedAppUserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public int Status { get; set; }
    public int Type { get; set; }
}
