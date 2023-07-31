using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Request
{
    public class OtpRequest
    {
        public string ClientKey { get; set; }
        public string Phone { get; set; }
    }
}
