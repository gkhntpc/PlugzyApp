using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class Notification:BaseEntity
    {
        [MaxLength(100),Required]
        public string Title { get; set; }
        [MaxLength(1000),Required]
        public string Description { get; set; }
        [Timestamp]
        public DateTime? ReadAt { get; set; }
        public string UserId { get; set; }
    }
}
