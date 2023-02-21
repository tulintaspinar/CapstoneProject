using CapstoneProject_EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class LoginValidator : AbstractValidator<AppUser>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
            RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("Kullanıcı şifresi boş geçilemez!");
        }
    }
}
