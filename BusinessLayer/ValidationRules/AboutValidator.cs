using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("E-Posta alanı boş geçilemez.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres alanı boş geçilemez.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Profil resim alanı boş geçilemez.");
        }
    }
}
