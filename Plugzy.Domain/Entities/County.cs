namespace Plugzy.Domain.Entities
{
    public class County : BaseEntity
    {
        public string Name { get; set; }
        public string CityId { get; set; }
        public City City { get; set; }
    }
}
