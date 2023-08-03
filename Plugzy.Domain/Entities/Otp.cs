using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class Otp : BaseEntity
    {
        [Required,MaxLength(100)]
        public int Code { get; set; }
        [Timestamp]
        public DateTime ValidTill { get; set; }
        [MaxLength(100),Required]
        public string Phone { get; set; }
        public int Attemps { get; set; }
        [Timestamp]
        public DateTime LoginTime { get; set; }
    }
}
