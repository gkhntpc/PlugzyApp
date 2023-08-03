using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Response
{
    public class OtpResponse
    {
        public int Seconds { get; set; }
        public int Code { get; set; }
        public bool Confirm { get; set; }
    }
}
