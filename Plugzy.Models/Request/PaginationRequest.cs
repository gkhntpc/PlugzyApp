using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Request
{
    public class PaginationRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Type { get; set; }
    }
}
