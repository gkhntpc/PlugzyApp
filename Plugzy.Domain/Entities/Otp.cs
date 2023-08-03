namespace Plugzy.Domain.Entities
{
    public class Otp : BaseEntity
    {
        public int Code { get; set; }
        public DateTime ValidTill { get; set; }
        public string Phone { get; set; }
        public bool Attemps { get; set; }
        public bool isActive { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
