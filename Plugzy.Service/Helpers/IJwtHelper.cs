using Plugzy.Domain.Entities;
using Plugzy.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.Helpers
{
    public interface IJwtHelper
    {
        AuthResponse CreateToken(AppUser appUser);
    }
}
