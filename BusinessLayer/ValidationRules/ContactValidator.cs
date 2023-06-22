using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("E-Posta alanı boş geçilemez.");
            RuleFor(x => x.LinkedIn).NotEmpty().WithMessage("LinkedIn alanı boş geçilemez.");
            RuleFor(x => x.Github).NotEmpty().WithMessage("Github alanı boş geçilemez.");
        }
    }
}
