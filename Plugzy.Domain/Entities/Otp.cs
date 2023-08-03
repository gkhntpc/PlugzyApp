using Plugzy.Domain.Abstract;
using Plugzy.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Domain.Entities
{
    public class Otp : BaseEntity, IEntity
    {
        public int Code { get; set; }
        public DateTime ValidTill { get; set; }
        public string Phone { get; set; }
        public bool Attmps { get; set; }
        public bool isActive { get; set; }
        public DateTime? LoginTime { get; set; }
        public Otp()
        {
            Id = Guid.NewGuid();
        }
    }
}
