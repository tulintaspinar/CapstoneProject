using CapstoneProject_DTOs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class NotificationAddValidator : AbstractValidator<NotificationAddDTO>
    {
        public NotificationAddValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Bildirim başlığı boş geçilemez!");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Bildirim metni boş geçilemez!");
        }
    }
}
