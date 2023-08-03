using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Models.Base;
using Plugzy.Models.Response;
using Plugzy.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IGenericRepositoryAsync<Otp> _otpRepository;
        public AuthenticationService(IGenericRepositoryAsync<Otp> otpRepository)
        {
            _otpRepository = otpRepository;
        }

        public async Task<CommandResult<Otp>> CheckOtpCode(string phoneNumber)
        {
            var checkCode = await _otpRepository.GetAllAsync(c => c.Phone == phoneNumber);
            var getLastCode = checkCode.OrderByDescending(i => i.ValidTill).FirstOrDefault();

            if (getLastCode != null && getLastCode.ValidTill > DateTime.Now)
            {
                return CommandResult<Otp>.GetSucceed(getLastCode);
            }
            
            return CommandResult<Otp>.GetFailed(MessageConstans.WrongOtpCode);
        }

        public async Task DisableOtpCode(Otp otp)
        {
            if(otp != null) 
            {
                otp.LoginTime = DateTime.Now;
                otp.Attmps = true;
                otp.isActive = false;
                await _otpRepository.UpdateAsync(otp);
            }
        }
    }
}
