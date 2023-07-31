namespace Plugzy.Domain.Entities
{
    public class Otp : BaseEntity
    {
        public int Code { get; set; }
        public TimeSpan ValidTill { get; set; }
        public string Phone { get; set; }
        public bool Attemps { get; set; }
        public bool isActive { get; set; }
        public TimeSpan LoginTime { get; set; }
    }
}
