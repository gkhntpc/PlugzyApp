namespace Plugzy.Domain.Entities
{
    public class Socket :BaseEntity
    {
        public string Number { get; set; }
        public decimal Kw { get; set; }
        public CurrentTypeEnum CurrentType { get; set; }
        public SocketTypeEnum SocketType { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public List<Station> Stations { get; set; }
    }
    public enum CurrentTypeEnum
    {
        Ac=0, Dc=1
    }
    public enum SocketTypeEnum
    {
        X=0,S,Bmw,Universal
    }
}
