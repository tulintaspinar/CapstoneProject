using CapstoneProject_DTOs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class ArticleEditValidator : AbstractValidator<ArticleEditDTO>
    {
        public ArticleEditValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez!");

            RuleFor(x => x.Title).MinimumLength(10).WithMessage("Başlık en az 10 karakter olmalıdır!");
            RuleFor(x => x.Description).MinimumLength(25).WithMessage("Açıklama 25 karakterden az olamaz!");
        }
    }
}
