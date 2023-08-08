using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Request
{
    public class CreateCityRequest
    {
        public Guid CountryId { get; set; }
        public string Name{ get; set; }
    }
}
