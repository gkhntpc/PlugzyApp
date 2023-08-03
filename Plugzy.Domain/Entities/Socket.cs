using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plugzy.Domain.Entities;

public class Socket : BaseEntity
{
    [MaxLength(100)]
    public string Number { get; set; }
    [Column(TypeName = "decimal(19,2)")]
    public decimal Kw { get; set; }
    [Column(TypeName = "tinyint")]
    public int CurrentType { get; set; }
    [Column(TypeName = "decimal(19,2)")]
    public decimal Price { get; set; }
    [Column(TypeName = "tinyint")]
    public int SocketType { get; set; }
    [Column(TypeName = "tinyint")]
    public int Status { get; set; }
    public bool IsActive { get; set; }

    public virtual Station Station { get; set; }

    public Socket()
    {
    }

    public Socket(Guid id, string number, decimal kw, int currentType, decimal price,
            int socketType, int status, bool isActive,
            Guid createdBy, DateTime createdAt,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        Number = number;
        Kw = kw;
        CurrentType = currentType;
        Price = price;
        SocketType = socketType;
        Status = status;
        IsActive = isActive;
    }

}
