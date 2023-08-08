using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Response
{
    public class CityResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public bool IsActive { get; set; }
        public Int64 CreatedAt { get; set; }
        public Int64? UpdatedAt{ get; set; }
    }
}
