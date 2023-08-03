namespace Plugzy.Domain.Entities;

public class Brand : BaseEntity
{
    public string Name { get; set; }
    public string Logo { get; set; }
    public bool IsActive { get; set; }

    public Brand()
    {
    }

    public Brand(Guid id, string name, string logo, bool isActive,
            Guid createdBy, DateTime createdAt,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        Name = name;
        Logo = logo;
        IsActive = isActive;
    }

}
