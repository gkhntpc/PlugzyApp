using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        [MaxLength(100)]
        public override string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string? FullName { get; set; }
        [MaxLength(100)]
        public override string? Email { get; set; }
        public Type Type { get; set; }
        public Status Status { get; set; }
        public Guid CreatedBy { get; set; }
        public Int64 CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Int64? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public Int64? DeletedAt { get; set; }
        public AppUser()
        {
            Id = Guid.NewGuid();
            CreatedBy = Id;
        }
    }
    public enum Status
    {
        Active = 1,
        Passive,
        Locked,
        Deleted,
        Banned
    }
    public enum Type
    {
        Client = 1,
        Admin
    }
}
