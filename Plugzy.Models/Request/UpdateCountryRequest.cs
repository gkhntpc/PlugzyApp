using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Request
{
    public class UpdateCountryRequest
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
