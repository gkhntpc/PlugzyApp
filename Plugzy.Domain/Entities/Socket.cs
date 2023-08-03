namespace Plugzy.Domain.Entities;

public class Socket : BaseEntity
{
    public string Number { get; set; }
    public decimal Kw { get; set; }
    public int CurrentType { get; set; }
    public decimal Price { get; set; }
    public int SocketType { get; set; }
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
