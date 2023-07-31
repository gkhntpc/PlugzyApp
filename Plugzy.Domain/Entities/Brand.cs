namespace Plugzy.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public List<Station> Stations { get; set; }
    }
}
