using CapstoneProject_DTOs.DTOs;
using FluentValidation;

namespace CapstoneProject_BusinessLayer.ValidationRules
{
    public class ArticleValidator : AbstractValidator<ArticleAddDTO>
    {
        public ArticleValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Makale başlığı boş bırakılamaz!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Makale başlığı en az 5 karakter olmalıdır!");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Makale başlığı en fazla 150 karakter olmalıdır!");

            RuleFor(x=>x.Description).NotEmpty().WithMessage("Makale açıklaması boş bırakılamaz!");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Makale açıklaması en az 50 karakter olmalıdır!");

            //RuleFor(x => x.ArticleCategoryID).NotEmpty().WithMessage("Makale türü seçiniz!");
        }
    }
}
