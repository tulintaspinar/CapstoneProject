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
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be left empty!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("The surname field cannot be left empty!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("The username field cannot be left empty!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("The email field cannot be left empty!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("The password field cannot be left empty!");
        }
    }
}
