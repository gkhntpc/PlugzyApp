using Plugzy.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Domain.Entities
{
    public class City:BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }
        public virtual Country? Country { get; set; }
        public City()
        {
            Id = Guid.NewGuid();
        }
    }
}
