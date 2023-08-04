using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public Guid CreatedBy { get; set; }
        [Timestamp,Required]
        public DateTime CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        [Timestamp]
        public DateTime? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        [Timestamp]
        public DateTime? DeletedAt { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
