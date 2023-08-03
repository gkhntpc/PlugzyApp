namespace Plugzy.Domain.Entities;

public class Otp : BaseEntity
{
    public string Code { get; set; }
    public DateTime ValidTill { get; set; }
    public string Phone { get; set; }
    public int Attempts { get; set; }
    public bool IsActive { get; set; }
    public DateTime? LoginTime { get; set; }

    public Otp()
    {
    }

    public Otp(Guid id, string code, DateTime validTill,
            string phone, int attempts, bool isActive,
            Guid createdBy, DateTime createdAt, DateTime? loginTime = null,
            Guid? updatedBy = null, DateTime? updatedAt = null,
            Guid? deletedBy = null, DateTime? deletedAt = null)
            : base(id, createdBy, createdAt, updatedBy, updatedAt, deletedBy, deletedAt)
    {
        Code = code;
        ValidTill = validTill;
        Phone = phone;
        Attempts = attempts;
        IsActive = isActive;
        LoginTime = loginTime;
    }
}
