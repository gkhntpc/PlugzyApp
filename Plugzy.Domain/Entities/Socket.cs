using System.ComponentModel.DataAnnotations;

namespace Plugzy.Domain.Entities
{
    public class Socket :BaseEntity
    {
        [MaxLength(100)]
        public string Number { get; set; }
        public decimal Kw { get; set; }
        public SocketCurrentType CurrentType { get; set; }
        public SocketType SocketType { get; set; }
        public decimal Price { get; set; }
        public IsIndividualPricingEnum IsIndividualPricing { get; set; }
        public SocketStatus Status { get; set; }
        public List<Station> Stations { get; set; }
    }
    public enum IsIndividualPricingEnum
    {
        Overall,Different
    }
    public enum SocketCurrentType
    {
        Ac=1, Dc=2
    }
    public enum SocketType
    {
        Tesla,Supercharger
    }
    public enum SocketStatus
    {
        Off=0,On, Malfunctioning,Maintenance,Reserved
    }
}
