namespace Plugzy.Domain.Entities;

public class Notification : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? ReadAt { get; set; }

    public Notification()
    {
    }

    public Notification(Guid id, string title, string description,
             Guid createdBy, DateTime createdAt, DateTime? readAt = null,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        Title = title;
        Description = description;
        ReadAt = readAt;
    }
}
