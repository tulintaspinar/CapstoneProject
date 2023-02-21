using CapstoneProject_DTOs.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class ArticleCategoryEditValidator : AbstractValidator<ArticleCategoryEditDTO>
    {
        public ArticleCategoryEditValidator()
        {
            RuleFor(x => x.TypesOfWritingName).NotEmpty().WithName("Yazı türü boş geçilemez!");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez!");
        }
    }
}
