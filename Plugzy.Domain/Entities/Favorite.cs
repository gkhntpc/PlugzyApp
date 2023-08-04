using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class Favorite:BaseEntity
    {
        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Station Station { get; set; }
        [Required]
        public string StationId { get; set; }

    }
}
