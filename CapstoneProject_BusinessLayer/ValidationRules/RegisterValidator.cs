using CapstoneProject_DTOs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemezy!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez!");
            RuleFor(x => x.Job).NotEmpty().WithMessage("Meslek alanı boş geçilemez!");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Yaş alanı boş geçilemez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez!");
        }
    }
}
