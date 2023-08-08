using Plugzy.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Domain.Entities
{
    public class Country:BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Country()
        {
            Id = Guid.NewGuid();
        }
    }
}
