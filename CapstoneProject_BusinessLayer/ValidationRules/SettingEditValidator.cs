using CapstoneProject_DTOs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class SettingEditValidator:AbstractValidator<UserEditDTO>
    {
        public SettingEditValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be left empty!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("The surname field cannot be left empty!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("The email field cannot be left empty!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("The phone field cannot be left empty!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("The username field cannot be left empty!");
            RuleFor(x => x.Age).NotEmpty().WithMessage("The age field cannot be left empty!");
            RuleFor(x => x.Job).NotEmpty().WithMessage("The job field cannot be left empty!");
        }
    }
}
