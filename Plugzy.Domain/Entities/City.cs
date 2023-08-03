namespace Plugzy.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public virtual Country Country { get; set; }
    public virtual ICollection<County> Counties { get; set; }

    public City()
    {
    }

    public City(Guid id, string name, bool isActive,
            Guid createdBy, DateTime createdAt,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        Name = name;
        IsActive = isActive;
    }
}
