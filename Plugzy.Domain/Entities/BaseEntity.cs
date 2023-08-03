namespace Plugzy.Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }

    public BaseEntity()
    {
    }

    public BaseEntity(Guid id)
    {
        Id = id;
    }

    public BaseEntity(Guid id, Guid createdBy, DateTime createdAt,
                    Guid? updatedBy = null, DateTime? updatedAt = null,
                    Guid? deletedBy = null, DateTime? deletedAt = null)
    {
        Id = id;
        CreatedBy = createdBy;
        CreatedAt = createdAt;
        UpdatedBy = updatedBy;
        UpdatedAt = updatedAt;
        DeletedBy = deletedBy;
        DeletedAt = deletedAt;
    }
}
