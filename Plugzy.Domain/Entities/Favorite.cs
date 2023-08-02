namespace Plugzy.Domain.Entities
{
    public class Favorite:BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Station Station { get; set; }
        public string StationId { get; set; }

    }
}
