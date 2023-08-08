using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Request
{
    public class UpdateCityRequest
    {
        public string Name{ get; set; }
        public Guid CountryId { get; set; }
        public bool IsActive { get; set; }
    }
}
