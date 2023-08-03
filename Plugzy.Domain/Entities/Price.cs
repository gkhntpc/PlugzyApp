using System.ComponentModel.DataAnnotations.Schema;

namespace Plugzy.Domain.Entities;

public class Price : BaseEntity
{
    [Column(TypeName = "tinyint")]
    public int CurrentType { get; set; }
    [Column(TypeName = "decimal(19,2)")]
    public decimal KwStart { get; set; }
    [Column(TypeName = "decimal(19,2)")]
    public decimal KwFinish { get; set; }
    [Column(TypeName = "tinyint")]
    public int SocketType { get; set; }
    [Column(TypeName = "decimal(19,2)")]
    public decimal PriceAmount { get; set; }

    public virtual Brand Brand { get; set; }

    public Price()
    {
    }

    public Price(Guid id, int currentType, int socketType,
            decimal kwStart, decimal kwFinish, decimal priceAmount,
            Guid createdBy, DateTime createdAt,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        CurrentType = currentType;
        SocketType = socketType;
        KwStart = kwStart;
        KwFinish = kwFinish;
        PriceAmount = priceAmount;
    }
}
