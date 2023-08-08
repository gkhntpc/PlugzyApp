using Plugzy.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Domain.Common
{
    public class BaseEntity:IEntity
    {
        public Guid Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public Int64 CreatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public Int64? UpdatedAt { get; set; }
        public Guid? DeletedBy { get; set; }
        public Int64? DeletedAt { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow.Ticks;
        }
        
    }
}
