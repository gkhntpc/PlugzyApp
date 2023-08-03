namespace Plugzy.Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<City> Cities { get; set; }

    public Country()
    {
    }

    public Country(Guid id, string name, bool isActive,
            Guid createdBy, DateTime createdAt,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        Name = name;
        IsActive = isActive;
    }
}
