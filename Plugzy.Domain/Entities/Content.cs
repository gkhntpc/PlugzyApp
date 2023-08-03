using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class Content : BaseEntity
    {
        [Required]
        public string Agreement { get; set; }
        public Language Language { get; set; }

    }
    public enum Language
    {
        Turkish=1,English
    }
}
