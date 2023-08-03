using Microsoft.AspNetCore.Identity;

namespace Plugzy.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
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
    }
}
