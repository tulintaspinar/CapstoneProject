using CapstoneProject_DTOs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class NewsArticleEditValidator : AbstractValidator<NewsArticleEditDTO>
    {
        public NewsArticleEditValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez!");
            RuleFor(x => x.Description).MinimumLength(25).WithMessage("Açıklama en az 25 karakter olmalıdır!");
        }
    }
}
