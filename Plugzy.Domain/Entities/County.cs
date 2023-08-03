namespace Plugzy.Domain.Entities;

public class County : BaseEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public virtual City City { get; set; }
    public virtual Country Country { get; set; }

    public County()
    {
    }

    public County(Guid id, string name, bool isActive,
            Guid createdBy, DateTime createdAt,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        Name = name;
        IsActive = isActive;
    }
}
