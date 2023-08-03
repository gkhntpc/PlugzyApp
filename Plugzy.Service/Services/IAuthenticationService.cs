using Plugzy.Domain.Entities;
using Plugzy.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.Services
{
    public interface IAuthenticationService
    {
        Task<CommandResult<Otp>> CheckOtpCode(string phoneNumber);
        Task DisableOtpCode(Otp otp);
    }
}
