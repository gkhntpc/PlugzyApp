using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class Brand : BaseEntity
    {
        [MaxLength(100),Required]
        public string Name { get; set; }
        [MaxLength(200),Required]
        public string Logo { get; set; }
        public List<Station> Stations { get; set; }
    }
}
