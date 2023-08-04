using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Plugzy.Domain.Entities
{
    public class Station : BaseEntity
    {
        public Brand Brand { get; set; }
        public string BrandId { get; set; }
        [MaxLength(100)]
        public string Number { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(200)]
        public string Latitude { get; set; }
        [MaxLength(200)]
        public string Longitude { get; set; }
        public County County { get; set; }
        public string CountyId { get; set; }
        public bool IsIndividualPricing { get; set; }
        public StationStatus Statu { get; set; }
        public List<Socket> Sockets { get; set; }

    }
    public enum StationStatus
    {
        Off,On,Maintenance
    }
}
