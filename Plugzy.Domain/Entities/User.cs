using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace Plugzy.Domain.Entities;

public class User : IdentityUser<Guid>
{
    [MaxLength(100)]
    public override string PhoneNumber { get; set; }
    [MaxLength(100)]
    public string? FullName { get; set; }
    [MaxLength(100)]
    public override string? Email { get; set; }
    [Column(TypeName = "tinyint")]
    public int Type { get; set; }
    [Column(TypeName = "tinyint")]
    public int Status { get; set; }
    public DateTime LastLogin { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Favorite> Favorite { get; set; }

    public User()
    {
    }

    public User(Guid id, int type, int status, DateTime lastLogin,
                Guid createdBy, DateTime createdAt, string? fullName = null,
                Guid? updatedBy = null, DateTime? updatedAt = null,
                Guid? deletedBy = null, DateTime? deletedAt = null)
    {
        Id = id;
        Type = type;
        Status = status;
        LastLogin = lastLogin;
        CreatedBy = createdBy;
        CreatedAt = createdAt;
        FullName = fullName;
        UpdatedBy = updatedBy;
        UpdatedAt = updatedAt;
        DeletedBy = deletedBy;
        DeletedAt = deletedAt;
    }
}
