namespace Plugzy.Domain.Entities;

public class Charge : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int CurrentType { get; set; }
    public decimal Kw { get; set; }
    public decimal Amount { get; set; }
    public int SocketType { get; set; }

    public virtual User User { get; set; }
    public virtual Station Station { get; set; }
    public virtual Socket Socket { get; set; }

    public Charge()
    {
    }

    public Charge(Guid id, DateTime startDate, int currentType,
            decimal kw, decimal amount, int socketType,
            Guid createdBy, DateTime createdAt, DateTime? endDate = null,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        StartDate = startDate;
        EndDate = endDate;
        CurrentType = currentType;
        Kw = kw;
        Amount = amount;
        SocketType = socketType;
    }
}
