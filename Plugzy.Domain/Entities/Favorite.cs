namespace Plugzy.Domain.Entities;

public class Favorite : BaseEntity
{
    public virtual User User { get; set; }
    public virtual Station Station { get; set; }

    public Favorite()
    {
    }

    public Favorite(Guid id, Guid createdBy, DateTime createdAt,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
    }
}
