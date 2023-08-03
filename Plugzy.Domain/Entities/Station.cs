using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plugzy.Domain.Entities;

public class Station : BaseEntity
{
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
    [Column(TypeName = "tinyint")]
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
