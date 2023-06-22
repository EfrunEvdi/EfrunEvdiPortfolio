using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SocialMediaValidator : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url alanı boş geçilemez.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon alanı boş geçilemez.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Durum alanı boş geçilemez.");
        }
    }
}
