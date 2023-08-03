namespace Plugzy.Domain.Entities;

public class Station : BaseEntity
{
    public string Number { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public int Status { get; set; }
    public bool IsIndividualPricing { get; set; }
    public bool IsActive { get; set; }

    public virtual Brand Brand { get; set; }
    public virtual County County { get; set; }
    public virtual ICollection<Socket> Sockets { get; set; }

    public Station()
    {
    }

    public Station(Guid id, string number, string name, string address,
                string latitude, string longitude, int status, bool isIndividualPricing,
                bool isActive, Guid createdBy, DateTime createdAt,
                Guid? updatedBy = null, DateTime? updatedAt = null,
                Guid? deletedBy = null, DateTime? deletedAt = null)
                : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        Number = number;
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
        Status = status;
        IsIndividualPricing = isIndividualPricing;
        IsActive = isActive;
    }

}
