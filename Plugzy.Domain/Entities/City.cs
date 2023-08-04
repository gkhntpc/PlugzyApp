using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class City:BaseEntity
    {
        [MaxLength(100),Required]
        public string Name { get; set; }
        public Country Country { get; set; }
        public string CountryId { get; set; }
    }
}
