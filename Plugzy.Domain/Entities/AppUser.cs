using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        [MaxLength(100)]
        public string? FullName { get; set; }
        public UserStatus Statu { get; set; }
        public UserTypes Type { get; set; }
        public DateTime LastLogin { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<Favorite> FavoriteStations { get; set; }
        public List<Notification> Notifications { get; set; }
        public void Created(string? createdBy=null) {
            CreatedAt=DateTime.Now;
            CreatedBy=createdBy;
        }
        public enum UserStatus
        {
            Active=1,Passive,Locked,Deleted,Blacklist
        }
        public enum UserTypes
        {
            Client=1, Admin
        }
    }
   
}
