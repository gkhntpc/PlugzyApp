using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class Country: BaseEntity
    {
        [MaxLength(100),Required]
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
