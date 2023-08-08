using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models.Response
{
    public class UserListResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public Int64 CreatedAt { get; set; }
        public Int64? UpdatedAt { get; set; }
        public int Type { get; set; }
    }
}
