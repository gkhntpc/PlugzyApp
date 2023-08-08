using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Request
{
    public class AuthorizeRequest
    {
        public string PhoneNumber{ get; set; }
        public int Code { get; set; }
    }
}
