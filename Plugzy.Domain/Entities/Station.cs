using System.Diagnostics.Metrics;

namespace Plugzy.Domain.Entities
{
    public class Station : BaseEntity
    {
        public Brand Brand { get; set; }
        public string BrandId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }

        public string CityId { get; set; }
        public City City { get; set; }

        public County County { get; set; }
        public string CountyId { get; set; } //Guid FK

        public bool IsIndividualPricing { get; set; }
        public StationStatusEnum Status { get; set; } //TinyInt(1)
        public List<Socket> Sockets { get; set; }

    }
    public enum StationStatusEnum
    {
        Off,On,Maintenance
    }
}
