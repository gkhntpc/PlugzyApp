using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class County : BaseEntity
    {
        [MaxLength(100),Required]
        public string Name { get; set; }
        public string CityId { get; set; }
        public City City { get; set; }
    }
}
