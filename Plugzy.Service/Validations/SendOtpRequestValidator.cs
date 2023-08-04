using FluentValidation;
using Plugzy.Models.Request;

namespace Plugzy.API.Validations
{
    public class SendOtpRequestValidator : AbstractValidator<SendOtpRequest>
    {
        public SendOtpRequestValidator()
        {
            RuleFor(x=>x.ClientId).NotNull().NotEmpty();
            RuleFor(x=>x.PhoneNumber).NotNull().NotEmpty();
        }
    }
}
