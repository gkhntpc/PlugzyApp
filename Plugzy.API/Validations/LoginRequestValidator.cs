using FluentValidation;
using Plugzy.Models.Request;

namespace Plugzy.API.Validations
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x=>x.PhoneNumber)
                .NotNull().WithMessage("Telefon numarası girmelisiniz.")
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .MaximumLength(20).WithMessage("Telefon numarası maksimum 20 karakter olabilir.");
            RuleFor(x => x.OtpCode)
                .NotNull().WithMessage("Otp Kodu boş geçilemez")
                .GreaterThanOrEqualTo(1000)
                .LessThanOrEqualTo(9999);
        }
    }
}
